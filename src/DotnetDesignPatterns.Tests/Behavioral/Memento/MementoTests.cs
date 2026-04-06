// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Behavioral.Memento;

namespace DotnetDesignPatterns.Tests.Behavioral.Memento
{
    public class MementoTests
    {
        [Fact]
        public void FileEditor_Write_ShouldUpdateContent()
        {
            // Arrange
            var editor = new FileEditor();

            // Act
            editor.Write("Hello World");

            // Assert
            Assert.Equal("Hello World", editor.Content);
        }

        [Fact]
        public void FileEditor_Write_WithNull_ShouldSetEmptyString()
        {
            // Arrange
            var editor = new FileEditor();

            // Act
            editor.Write(null!);

            // Assert
            Assert.Equal(string.Empty, editor.Content);
        }

        [Fact]
        public void FileEditor_Save_ShouldReturnMemento()
        {
            // Arrange
            var editor = new FileEditor();
            editor.Write("Test Content");

            // Act
            var memento = editor.Save();

            // Assert
            Assert.NotNull(memento);
            Assert.Equal("Test Content", memento.Content);
        }

        [Fact]
        public void FileEditor_Restore_ShouldRestoreContent()
        {
            // Arrange
            var editor = new FileEditor();
            editor.Write("Original Content");
            var memento = editor.Save();
            editor.Write("Modified Content");

            // Act
            editor.Restore(memento);

            // Assert
            Assert.Equal("Original Content", editor.Content);
        }

        [Fact]
        public void FileEditor_Restore_WithNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var editor = new FileEditor();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => editor.Restore(null!));
        }

        [Fact]
        public void FileHistory_Save_ShouldStoreState()
        {
            // Arrange
            var editor = new FileEditor();
            var history = new FileHistory(editor);
            editor.Write("Version 1");

            // Act & Assert
            var exception = Record.Exception(() => history.Save());
            Assert.Null(exception);
        }

        [Fact]
        public void FileHistory_Undo_ShouldRestorePreviousState()
        {
            // Arrange
            var editor = new FileEditor();
            var history = new FileHistory(editor);
            editor.Write("Version 1");
            history.Save();
            editor.Write("Version 2");
            history.Save();

            // Act
            history.Undo();

            // Assert
            Assert.Equal("Version 2", editor.Content);
        }

        [Fact]
        public void FileHistory_Undo_WhenNoStates_ShouldIndicateNoStatesToUndo()
        {
            // Arrange
            var editor = new FileEditor();
            var history = new FileHistory(editor);

            // Act
            var output = CaptureConsoleOutput(() => history.Undo());

            // Assert
            Assert.Contains("No states to undo", output);
        }

        [Fact]
        public void FileHistory_Redo_ShouldRestoreUndoneState()
        {
            // Arrange
            var editor = new FileEditor();
            var history = new FileHistory(editor);
            editor.Write("Version 1");
            history.Save();
            editor.Write("Version 2");
            history.Save();
            history.Undo();

            // Act
            history.Redo();

            // Assert
            Assert.Equal("Version 2", editor.Content);
        }

        [Fact]
        public void FileHistory_Redo_WhenNoStates_ShouldIndicateNoStatesToRedo()
        {
            // Arrange
            var editor = new FileEditor();
            var history = new FileHistory(editor);

            // Act
            var output = CaptureConsoleOutput(() => history.Redo());

            // Assert
            Assert.Contains("No states to redo", output);
        }

        [Fact]
        public void FileHistory_Save_ShouldClearRedoStack()
        {
            // Arrange
            var editor = new FileEditor();
            var history = new FileHistory(editor);
            editor.Write("Version 1");
            history.Save();
            editor.Write("Version 2");
            history.Save();
            history.Undo();
            editor.Write("Version 3");
            history.Save();

            // Act
            var output = CaptureConsoleOutput(() => history.Redo());

            // Assert
            Assert.Contains("No states to redo", output);
        }

        private static string CaptureConsoleOutput(Action action)
        {
            var originalOutput = Console.Out;
            try
            {
                using var stringWriter = new StringWriter();
                Console.SetOut(stringWriter);
                action.Invoke();
                return stringWriter.ToString();
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }
    }
}
