using System;

namespace ITG.Models
{

    public class FormItem
    {

        /*
             <FlagsAttribute>
        Public Enum ITGComponent
            None = 0
            fc_LEFT = 1  ' left alignment, where applicable
            fc_RIGHT = 2 ' right alignment, where applicable
            ' fc_LINE = 1 ' maybe this should just be removed ...
            ' fc_BOX = 2 ' Frame object; maybe this should just be removed ...
            fc_TREE = 4 ' Data entry tree
            fc_GRID = 8 ' Grid object
            fc_RIBBON = 16 ' Ribbon object
            fc_TABSTRIP = 32 ' Page control (tab strip)
            fc_PICTURE = 64 ' picture object
            fc_REQ = 128 ' Medcin entry is required
            fc_CHKY = 256 ' Medcin yes checkbox component
            fc_CHKN = 512 ' Medcin no checkbox component
            fc_ROS = 1024 ' Medcin ROS state
            fc_VALUE = 2048 ' Medcin textbox to enter value
            fc_BROWSE = 4096 ' Medcin button to browse children findings
            fc_NOTE = 8192 ' Medcin Note button to popup note box for Medcinid > 0. When the flag value is identical to fc_Note 
            ' and the Medcinid is 0, the record either: (Page=0) the pre-defined chapter headings in the 
            ' description and itemdata properties (substrings are delimited with a tilde character), or (Page=1) 
            ' the pre-defined Encounter-specific User SubGroup headings in the description and itemdata properties (substrings are Tab delimited)
            fc_LINK = 16384 ' button to link to another form
            fc_LABEL = 32768 ' label for captions
            fc_UPDOWN = 65536 ' Medcin UpDown button
            fc_HASDATA = 131072 ' Logic display indicator
            fc_REFERENCE = 262144 ' reference document, or finding reference button
            fc_ONSET = 524288 ' Medcin Onset combo
            fc_FORM = 1048576 ' form size
            fc_SEARCH = 2097152 ' Word search toolbar
            fc_ACTION = 2097152 ' Action component
            fc_TEXTBOX = 4194304 ' Medcin free-text entry box
            fc_DROPBOX = 8388608 ' Medcin Picklist ' dropdown listbox
            fc_LISTBOX = 16777216 ' Medcin Picklist Full listbox
            fc_LISTVIEW = 20971520 ' Medcin Picklist ' multi-column listview
            fc_INLINENOTE = 33554432 ' Medcin inline textbox
            fc_RICHTEXTBOX = 37748736 ' Medcin rich textbox
            fc_PICKLIST = 134217728 ' Picklist
            fc_ROSTGL = 268435456 ' Medcin ROS toggle button
            fc_WINDOW = 536870912 ' Window
            fc_TIMING = 1073741824 ' Timing Button component
        End Enum
         */

        public FormItem()
        {
        }
    }
}