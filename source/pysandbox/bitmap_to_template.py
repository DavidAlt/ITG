from PIL import Image

im = Image.open('flag.png')

print(im.format, im.size, im.mode)
pix = im.load()


width, height = im.size

'''
for y in range(0,height):
    for x in range(0,width):
        print(pix[x,y])
'''
print(pix[0,0])
print(pix[0,1])
print((pix[0,0] == pix[0,1]))
print(pix[1,2])
print((pix[0,0] == pix[1,2]))