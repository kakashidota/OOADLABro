using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PropertyChanged;
using TheLab.Models;
using Xamarin.Forms;

namespace TheLab.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MyViewModel
    {
        private ObservableCollection<string> listOfWords = new ObservableCollection<string>();
        public UndoRedo<string> UndoRedo = new UndoRedo<string>();
        public AddWord AddString = new AddWord();
        public ICommand Execute { get; set; }
        public ICommand UndoCommand { get; set; }
        public ICommand RedoCommand { get; set; }
        public string Word { get; set; }
        public ObservableCollection<string> ListOfWords { get => listOfWords; set => listOfWords = value; }

        public MyViewModel()
        {
            Execute = new Command(
                execute: onClick,
                canExecute: obj => { return true; }
            );
            UndoCommand = new Command(
                execute: Undo,
                canExecute: obj => { return true; }
            );
            RedoCommand = new Command(
                execute: Redo,
                canExecute: obj => { return true; }
            );
        }

        private void Redo(object obj)
        {
            if (UndoRedo._redoStack.Count > 0)
            {
                ListOfWords.Add(UndoRedo.Redo());
            }
        }

        private void Undo(object obj)
        {
            if (ListOfWords.Count > 0)
                ListOfWords.Remove(UndoRedo.Undo(ListOfWords[ListOfWords.Count - 1]));
        }

        private void onClick(object obj)
        {
            ListOfWords.Add(UndoRedo.Do(AddString, Word));
            int test = UndoRedo._undoStack.Count;
            Word = "";
        }
    }
}
