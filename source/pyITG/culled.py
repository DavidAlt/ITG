import math

from PyQt5.QtCore import (pyqtSlot, pyqtSignal, QLineF, QPointF, QRect, QRectF, QSize,
        QSizeF, Qt)
from PyQt5.QtGui import (QBrush, QColor, QFont, QIcon, QIntValidator, QPainter,
        QPainterPath, QPen, QPixmap, QPolygonF)
from PyQt5.QtWidgets import (QAction, QApplication, QButtonGroup, QComboBox,
        QFontComboBox, QGraphicsItem, QGraphicsLineItem, QGraphicsPolygonItem,
        QGraphicsScene, QGraphicsTextItem, QGraphicsView, QGridLayout,
        QHBoxLayout, QLabel, QMainWindow, QMenu, QMessageBox, QSizePolicy,
        QToolBox, QToolButton, QWidget)

import ITGscene_rc


class ITGItem(QGraphicsPolygonItem):
    Square, Diamond, Parallelogram = range(3)

    def __init__(self, ITGType, contextMenu, parent=None):
        super(ITGItem, self).__init__(parent)

        self.ITGType = ITGType
        self.contextMenu = contextMenu

        path = QPainterPath()

        if self.ITGType == self.Diamond:
            self.myPolygon = QPolygonF([
                    QPointF(-100, 0), QPointF(0, 100),
                    QPointF(100, 0), QPointF(0, -100),
                    QPointF(-100, 0)])
        elif self.ITGType == self.Square:
            self.myPolygon = QPolygonF([
                    QPointF(-100, -100), QPointF(100, -100),
                    QPointF(100, 100), QPointF(-100, 100),
                    QPointF(-100, -100)])
        else: # it's a parallelogram
            self.myPolygon = QPolygonF([
                    QPointF(-120, -80), QPointF(-70, 80),
                    QPointF(120, 80), QPointF(70, -80),
                    QPointF(-120, -80)])

        self.setPolygon(self.myPolygon)
        self.setFlag(QGraphicsItem.ItemIsMovable, True)
        self.setFlag(QGraphicsItem.ItemIsSelectable, True)

    def image(self):
        pixmap = QPixmap(250, 250)
        pixmap.fill(Qt.transparent)
        painter = QPainter(pixmap)
        painter.setPen(QPen(Qt.black, 8))
        painter.translate(125, 125)
        painter.drawPolyline(self.myPolygon)
        return pixmap

    def contextMenuEvent(self, event):
        self.scene().clearSelection()
        self.setSelected(True)
        self.myContextMenu.exec_(event.screenPos())

    def itemChange(self, change, value):
        if change == QGraphicsItem.ItemPositionChange:
            pass
        return value # Does this even do anything?

    def get_ITGType_as_str(self):
        if self.ITGType == 0: 
            value = 'Square'
        elif self.ITGType == 1: 
            value = 'Diamond'
        elif self.ITGType == 2:
            value = 'Parallelogram'
        return value


class ITGScene(QGraphicsScene):

    InsertItem = 0
    MoveItem  = 1

    itemInserted = pyqtSignal(ITGItem)
    itemSelected = pyqtSignal(QGraphicsItem)

    def __init__(self, itemMenu, parent=None):
        super(ITGScene, self).__init__(parent)

        self.myItemMenu = itemMenu
        self.myMode = self.MoveItem
        self.myItemType = ITGItem.Square
        self.myItemColor = Qt.red
        #self.myTextColor = Qt.black
        self.myFont = QFont()

    def setItemColor(self, color):
        self.myItemColor = color
        if self.isItemChange(ITGItem):
            item = self.selectedItems()[0]
            item.setBrush(self.myItemColor)

    def setMode(self, mode):
        self.myMode = mode

    def getMode(self):
        if self.myMode == 0:
            mode = 'InsertItem'
        elif self.myMode == 1:
            mode = 'MoveItem'
        else:
            mode = 'Mode not set'
        return mode

    def setItemType(self, type):
        self.myItemType = type

    def editorLostFocus(self, item):
        cursor = item.textCursor()
        cursor.clearSelection()
        item.setTextCursor(cursor)

        if item.toPlainText():
            self.removeItem(item)
            item.deleteLater()

    def mousePressEvent(self, mouseEvent):
        if mouseEvent.button() == Qt.LeftButton: 
            if self.myMode == self.InsertItem:
                item = ITGItem(self.myItemType, self.myItemMenu)
                item.setBrush(self.myItemColor)
                self.addItem(item)
                item.setPos(mouseEvent.scenePos())
                self.itemInserted.emit(item)
            # elif ... you had other Insert modes, you could handle them here

        elif mouseEvent.button() == Qt.MiddleButton:
            if len(self.selectedItems()) == 0:
                print('Nothing selected')
            else: 
                for item in self.selectedItems():
                    print(item.get_ITGType_as_str())

        super(ITGScene, self).mousePressEvent(mouseEvent)

    def mouseMoveEvent(self, mouseEvent):
        super(ITGScene, self).mouseMoveEvent(mouseEvent)

    def mouseReleaseEvent(self, mouseEvent):
        super(ITGScene, self).mouseReleaseEvent(mouseEvent)

    def isItemChange(self, type):
        for item in self.selectedItems():
            if isinstance(item, type):
                return True
        return False



class MainWindow(QMainWindow):

    def __init__(self):
        super(MainWindow, self).__init__()

        self.createActions()
        self.createMenus()
        self.createToolBox()
        self.createStatusBar()
        
        self.scene = ITGScene(self.itemMenu)
        self.scene.setSceneRect(QRectF(0, 0, 5000, 5000))
        self.scene.itemInserted.connect(self.itemInserted)
        self.scene.itemSelected.connect(self.itemSelected)
        
        # ================================================================
        #         THIS IS THE PROBLEM SECTION 
        # THIS CAUSES TypeError: native Qt signal is not callable
        # To reproduce the error, run the program, click on one of the 
        # shapes, then click on the scene area
        # ================================================================
        self.scene.selectionChanged.connect(self.print_item_info) # this one doesn't work

        self.createToolbars()

        layout = QHBoxLayout()
        layout.addWidget(self.toolBox)
        self.view = QGraphicsView(self.scene) # view and scene established together
        layout.addWidget(self.view)

        self.widget = QWidget()
        self.widget.setLayout(layout)

        self.setCentralWidget(self.widget)
        self.setWindowTitle("ITG: Illegitimate Template Generator")

    #@pyqtSlot() # Adding this does not change the error
    def print_item_info(self):
        for item in self.scene.selectedItems():
            print(item)

    def buttonGroupClicked(self, id):
        buttons = self.buttonGroup.buttons()
        for button in buttons:
            if self.buttonGroup.button(id) != button:
                button.setChecked(False)

        self.scene.setItemType(id)
        self.scene.setMode(ITGScene.InsertItem)
        self.updateStatusBar()
        

    def deleteItem(self):
        for item in self.scene.selectedItems():
            self.scene.removeItem(item)

    def pointerGroupClicked(self, i):
        self.scene.setMode(self.pointerTypeGroup.checkedId())
        self.updateStatusBar()

    def bringToFront(self):
        if not self.scene.selectedItems():
            return

        selectedItem = self.scene.selectedItems()[0]
        overlapItems = selectedItem.collidingItems()

        zValue = 0
        for item in overlapItems:
            if (item.zValue() >= zValue and isinstance(item, ITGItem)):
                zValue = item.zValue() + 0.1
        selectedItem.setZValue(zValue)

    def sendToBack(self):
        if not self.scene.selectedItems():
            return

        selectedItem = self.scene.selectedItems()[0]
        overlapItems = selectedItem.collidingItems()

        zValue = 0
        for item in overlapItems:
            if (item.zValue() <= zValue and isinstance(item, ITGItem)):
                zValue = item.zValue() - 0.1
        selectedItem.setZValue(zValue)

    def itemInserted(self, item):
        self.pointerTypeGroup.button(ITGScene.MoveItem).setChecked(True)
        self.scene.setMode(self.pointerTypeGroup.checkedId())
        self.updateStatusBar()
        self.buttonGroup.button(item.ITGType).setChecked(False)

    def sceneScaleChanged(self, scale):
        newScale = scale.left(scale.indexOf("%")).toDouble()[0] / 100.0
        oldMatrix = self.view.matrix()
        self.view.resetMatrix()
        self.view.translate(oldMatrix.dx(), oldMatrix.dy())
        self.view.scale(newScale, newScale)

    def itemColorChanged(self):
        self.fillAction = self.sender()
        self.fillColorToolButton.setIcon(
                self.createColorToolButtonIcon( ':/images/floodfill.png',
                        QColor(self.fillAction.data())))
        self.fillButtonTriggered()


    def fillButtonTriggered(self):
        self.scene.setItemColor(QColor(self.fillAction.data()))


    def itemSelected(self, item):
        font = item.font()
        color = item.defaultTextColor()
        self.fontCombo.setCurrentFont(font)
        self.fontSizeCombo.setEditText(str(font.pointSize()))
        self.boldAction.setChecked(font.weight() == QFont.Bold)
        self.italicAction.setChecked(font.italic())
        self.underlineAction.setChecked(font.underline())



    def about(self):
        QMessageBox.about(self, "About ITG Scene",
                "The <b>ITG Scene</b> example shows use of the graphics framework.")

    def createToolBox(self):
        self.buttonGroup = QButtonGroup()
        self.buttonGroup.setExclusive(False)
        self.buttonGroup.buttonClicked[int].connect(self.buttonGroupClicked)

        layout = QGridLayout()
        layout.addWidget(self.createCellWidget("Diamond", ITGItem.Diamond),
                0, 0)
        layout.addWidget(self.createCellWidget("Square", ITGItem.Square), 0,
                1)
        layout.addWidget(self.createCellWidget("Parallelogram", ITGItem.Parallelogram),
                1, 0)

        layout.setRowStretch(3, 10)
        layout.setColumnStretch(2, 10)

        itemWidget = QWidget()
        itemWidget.setLayout(layout)

        self.backgroundButtonGroup = QButtonGroup()
        
        self.toolBox = QToolBox()
        self.toolBox.setSizePolicy(QSizePolicy(QSizePolicy.Maximum, QSizePolicy.Ignored))
        self.toolBox.setMinimumWidth(itemWidget.sizeHint().width())
        self.toolBox.addItem(itemWidget, "Basic Components")

    def createActions(self):
        self.toFrontAction = QAction(
                QIcon(':/images/bringtofront.png'), "Bring to &Front",
                self, shortcut="Ctrl+F", statusTip="Bring item to front",
                triggered=self.bringToFront)

        self.sendBackAction = QAction(
                QIcon(':/images/sendtoback.png'), "Send to &Back", self,
                shortcut="Ctrl+B", statusTip="Send item to back",
                triggered=self.sendToBack)

        self.deleteAction = QAction(QIcon(':/images/delete.png'),
                "&Delete", self, shortcut="Delete",
                statusTip="Delete item from ITG",
                triggered=self.deleteItem)

        self.exitAction = QAction("E&xit", self, shortcut="Ctrl+X",
                statusTip="Quit SceneITG example", triggered=self.close)

        self.aboutAction = QAction("A&bout", self, shortcut="Ctrl+B",
                triggered=self.about)

    def createMenus(self):
        self.fileMenu = self.menuBar().addMenu("&File")
        self.fileMenu.addAction(self.exitAction)

        self.itemMenu = self.menuBar().addMenu("&Item")
        self.itemMenu.addAction(self.deleteAction)
        self.itemMenu.addSeparator()
        self.itemMenu.addAction(self.toFrontAction)
        self.itemMenu.addAction(self.sendBackAction)

        self.aboutMenu = self.menuBar().addMenu("&Help")
        self.aboutMenu.addAction(self.aboutAction)

    def createToolbars(self):
        self.editToolBar = self.addToolBar("Edit")
        self.editToolBar.addAction(self.deleteAction)
        self.editToolBar.addAction(self.toFrontAction)
        self.editToolBar.addAction(self.sendBackAction)

        self.fillColorToolButton = QToolButton()
        self.fillColorToolButton.setPopupMode(QToolButton.MenuButtonPopup)
        self.fillColorToolButton.setMenu(
                self.createColorMenu(self.itemColorChanged, Qt.red))
        self.fillAction = self.fillColorToolButton.menu().defaultAction()
        self.fillColorToolButton.setIcon(
                self.createColorToolButtonIcon(':/images/floodfill.png',
                        Qt.red))
        self.fillColorToolButton.clicked.connect(self.fillButtonTriggered)

        self.colorToolBar = self.addToolBar("Color")
        self.colorToolBar.addWidget(self.fillColorToolButton)
        

        pointerButton = QToolButton()
        pointerButton.setCheckable(True)
        pointerButton.setChecked(True)
        pointerButton.setIcon(QIcon(':/images/pointer.png'))

        self.pointerTypeGroup = QButtonGroup()
        self.pointerTypeGroup.addButton(pointerButton, ITGScene.MoveItem)
        self.pointerTypeGroup.buttonClicked[int].connect(self.pointerGroupClicked)

        self.sceneScaleCombo = QComboBox()
        self.sceneScaleCombo.addItems(["50%", "75%", "100%", "125%", "150%"])
        self.sceneScaleCombo.setCurrentIndex(2)
        self.sceneScaleCombo.currentIndexChanged[str].connect(self.sceneScaleChanged)

        self.pointerToolbar = self.addToolBar("Pointer type")
        self.pointerToolbar.addWidget(pointerButton)
        self.pointerToolbar.addWidget(self.sceneScaleCombo)

    def createBackgroundCellWidget(self, text, image):
        button = QToolButton()
        button.setText(text)
        button.setIcon(QIcon(image))
        button.setIconSize(QSize(50, 50))
        button.setCheckable(True)
        self.backgroundButtonGroup.addButton(button)

        layout = QGridLayout()
        layout.addWidget(button, 0, 0, Qt.AlignHCenter)
        layout.addWidget(QLabel(text), 1, 0, Qt.AlignCenter)

        widget = QWidget()
        widget.setLayout(layout)

        return widget

    def createCellWidget(self, text, ITGType):
        item = ITGItem(ITGType, self.itemMenu)
        icon = QIcon(item.image())

        button = QToolButton()
        button.setIcon(icon)
        button.setIconSize(QSize(50, 50))
        button.setCheckable(True)
        self.buttonGroup.addButton(button, ITGType)

        layout = QGridLayout()
        layout.addWidget(button, 0, 0, Qt.AlignHCenter)
        layout.addWidget(QLabel(text), 1, 0, Qt.AlignCenter)

        widget = QWidget()
        widget.setLayout(layout)

        return widget

    def createColorMenu(self, slot, defaultColor):
        colors = [Qt.black, Qt.white, Qt.red, Qt.blue, Qt.yellow]
        names = ["black", "white", "red", "blue", "yellow"]

        colorMenu = QMenu(self)
        for color, name in zip(colors, names):
            action = QAction(self.createColorIcon(color), name, self,
                    triggered=slot)
            action.setData(QColor(color)) 
            colorMenu.addAction(action)
            if color == defaultColor:
                colorMenu.setDefaultAction(action)
        return colorMenu

    def createColorToolButtonIcon(self, imageFile, color):
        pixmap = QPixmap(50, 80)
        pixmap.fill(Qt.transparent)
        painter = QPainter(pixmap)
        image = QPixmap(imageFile)
        target = QRect(0, 0, 50, 60)
        source = QRect(0, 0, 42, 42)
        painter.fillRect(QRect(0, 60, 50, 80), color)
        painter.drawPixmap(target, image, source)
        painter.end()

        return QIcon(pixmap)

    def createColorIcon(self, color):
        pixmap = QPixmap(20, 20)
        painter = QPainter(pixmap)
        painter.setPen(Qt.NoPen)
        painter.fillRect(QRect(0, 0, 20, 20), color)
        painter.end()

        return QIcon(pixmap)

    def createStatusBar(self):
        self.sbar = self.statusBar()
        
        self.lbl_mode = QLabel('Mode: not set')
        self.sbar.addPermanentWidget(self.lbl_mode)

        self.lbl_selection = QLabel('Sel: none')
        self.sbar.addPermanentWidget(self.lbl_selection)

    def updateStatusBar(self):
        self.lbl_mode.setText('Mode: ' + self.scene.getMode())
        #! This section is not working!!!
        if len(self.scene.selectedItems()) == 0:
            self.lbl_selection.setText('Sel: none')
        elif len(self.scene.selectedItems()) == 1:
            self.lbl_selection.setText('Sel: ' + self.scene.selectedItems()[0].get_ITGType_as_str())
        elif len(self.scene.selectedItems()) > 1:
            self.lbl_selection.setText('Sel: <multiple>')
        
        #self.lbl_selection.setText('Sel: ' + self.scene.selectedItems)
        #for item in self.scene.selectedItems():
        #    print(item)

if __name__ == '__main__':

    import sys

    app = QApplication(sys.argv)

    mainWindow = MainWindow()
    mainWindow.setGeometry(100, 100, 800, 500)
    mainWindow.show()

    sys.exit(app.exec_())
