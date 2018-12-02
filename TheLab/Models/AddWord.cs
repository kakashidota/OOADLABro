using System;
using System.Collections.Generic;
using PropertyChanged;

namespace TheLab.Models
{
    [AddINotifyPropertyChangedInterface]

    public class AddWord : ICommand<String>
    {

        private List<string> undoList;
        private List<string> redoList;

        public AddWord()
        {
            undoList = new List<string>();
            redoList = new List<string>();
        }

        public string Execute(string word)
        {
            undoList.Add(word);
            return word;
        }

        public string Redo()
        {
            string wordFromList = redoList[redoList.Count - 1];
            redoList.Remove(wordFromList);
            undoList.Add(wordFromList);
            return wordFromList;
        }

        public string Undo()
        {
            if (undoList.Count < 1){
                return "";
            } else {
                string wordFromList = undoList[undoList.Count - 1];
                undoList.Remove(wordFromList);
                redoList.Add(wordFromList);
                return wordFromList;
            }
        }
    }
}
