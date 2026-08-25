"""Hand written summaries for every documented declaration in the library.

Keyed by the path of the file relative to src/DotnetDesignPatterns. The special
key "@type" documents the type itself. An overloaded member is keyed as
"Name#FirstParameterType". A value can be a plain summary, or a
(summary, returns) pair when the member returns something.

Nothing here is generated. apply_xml_docs.py fails on a declaration that has no
entry, which keeps the table honest as the code changes.
"""

# Parameter descriptions, keyed by parameter name. The codebase uses the same
# name for the same thing everywhere, so one entry serves every occurrence.
PARAMETERS = {
    "osType": "The requested operating system, either windows or linux.",
    "output": "Where the product writes its narration. Defaults to the console.",
    "osName": "The name of the operating system.",
    "version": "The version string of the operating system.",
    "fileSystem": "The file system implementation to write through.",
    "networkSettings": "The network configuration to record.",
    "enable": "True to enable the firewall, false to leave it off.",
    "name": "The name of the element.",
    "depth": "The indentation depth used when printing the tree.",
    "size": "The size of the file in bytes.",
    "component": "The child component.",
    "element": "The element to add to the collection.",
    "visitor": "The visitor that will operate on this element.",
    "file": "The file being visited.",
    "directory": "The directory being visited.",
    "context": "The context whose state may change.",
    "mediator": "The mediator that coordinates the colleagues.",
    "sender": "The colleague that raised the event.",
    "eventCode": "One of the constants declared in FileEvents.",
    "filename": "The name of the file.",
    "fileName": "The name of the file.",
    "filePath": "The path of the file.",
    "path": "The directory to watch.",
    "content": "The content to write.",
    "newContent": "The content that replaces what the file holds.",
    "message": "The message to send.",
    "observer": "The observer to register or remove.",
    "changeType": "What happened to the file, for example created or deleted.",
    "command": "The command the invoker will run.",
    "memento": "The snapshot to restore.",
    "notification": "The notification this decorator wraps.",
    "compressionStrategy": "The compression algorithm to use from now on.",
    "strategy": "The compression algorithm to use from now on.",
    "nextHandler": "The handler that receives the request if this one declines it.",
    "operationType": "The operation being requested, for example read or write.",
    "fileType": "The extension shared by the files that use this metadata.",
    "owner": "The owner shared by the files that use this metadata.",
    "userRole": "The role of the caller, checked before the resource is reached.",
    "extension": "The extension the filter matches.",
    "disposing": "True when called from Dispose, false when called from a finalizer.",
    "elements": "The elements the iterator will walk.",
    "fileEditor": "The editor whose snapshots this caretaker keeps.",
    "windowsOS": "The Windows implementation being adapted.",
    "linuxOS": "The Linux implementation being adapted.",
    "fileExplorer": "The colleague that selects the file to act on.",
    "fileOperationHandler": "The colleague that performs the file operations.",
    "logger": "The colleague that records what happened.",
}

# Every class that narrates what it is doing exposes the same sink, documented once here.
OUTPUT_SUMMARY = ("Where this example writes its narration. It defaults to the console, and a "
                  "caller, or a test, can point it somewhere else.")

DOCS = {
    # ---------------------------------------------------------------- creational
    "Creational/Singleton/LazySingleton.cs": {
        "@type": "A singleton whose instance is created by Lazy&lt;T&gt;, which handles the "
                 "synchronisation and guarantees that the factory runs once.",
        "Instance": ("The single instance, created on first access.",
                     "The one instance of the class."),
        "DoSomething": "Stands in for whatever shared resource the singleton owns.",
    },
    "Creational/Singleton/LockSingleton.cs": {
        "@type": "A singleton built with double-checked locking, kept as a counterpoint to "
                 "the Lazy&lt;T&gt; version.",
        "Instance": ("The single instance, created under a lock on first access.",
                     "The one instance of the class."),
        "DoSomething": "Stands in for whatever shared resource the singleton owns.",
    },
    "Creational/Factory/IOperatingSystem.cs": {
        "@type": "The product created by the factory.",
        "Configure": "Applies the configuration specific to this operating system.",
        "DisplayInfo": "Writes a short description of the operating system.",
    },
    "Creational/Factory/WindowsOS.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The Windows product.",
        "Configure": "Applies the Windows configuration.",
        "DisplayInfo": "Writes a short description of the Windows product.",
    },
    "Creational/Factory/LinuxOS.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The Linux product.",
        "Configure": "Applies the Linux configuration.",
        "DisplayInfo": "Writes a short description of the Linux product.",
    },
    "Creational/Factory/OperatingSystemFactory.cs": {
        "@type": "Creates an operating system without the caller naming a concrete type.",
        "CreateOperatingSystem": ("Creates the operating system matching the requested type.",
                                  "A product ready to be configured."),
    },
    "Creational/AbstractFactory/IOperatingSystem.cs": {
        "@type": "The product of an operating system factory.",
        "Configure": "Applies the configuration specific to this operating system.",
        "DisplayInfo": "Writes a short description of the operating system.",
    },
    "Creational/AbstractFactory/WindowsOS.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The Windows member of the product family.",
        "Configure": "Applies the Windows configuration.",
        "DisplayInfo": "Writes a short description of the Windows product.",
    },
    "Creational/AbstractFactory/LinuxOS.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The Linux member of the product family.",
        "Configure": "Applies the Linux configuration.",
        "DisplayInfo": "Writes a short description of the Linux product.",
    },
    "Creational/AbstractFactory/IOperatingSystemFactory.cs": {
        "@type": "Creates one coherent family of operating system products.",
        "CreateOperatingSystem": ("Creates the product belonging to this family.",
                                  "A product of the family this factory represents."),
    },
    "Creational/AbstractFactory/WindowsOSFactory.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "Produces the Windows family of products.",
        "CreateOperatingSystem": ("Creates the Windows product.", "A configured Windows product."),
    },
    "Creational/AbstractFactory/LinuxOSFactory.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "Produces the Linux family of products.",
        "CreateOperatingSystem": ("Creates the Linux product.", "A configured Linux product."),
    },
    "Creational/Builder/OperatingSystemConfig.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The product the builder assembles, one setting at a time.",
        "OSName": "The name of the operating system.",
        "Version": "The version string.",
        "FileSystem": "The file system the installation uses.",
        "IsFirewallEnabled": "Whether the firewall is turned on.",
        "NetworkSettings": "The network configuration.",
        "DisplayConfig": "Writes the whole configuration.",
    },
    "Creational/Builder/IOperatingSystemConfigBuilder.cs": {
        "@type": "Assembles an operating system configuration step by step. Every step "
                 "returns the builder, so the calls chain into one expression.",
        "SetOSName": ("Records the name of the operating system.", "The same builder."),
        "SetVersion": ("Records the version string.", "The same builder."),
        "SetFileSystem": ("Records the file system.", "The same builder."),
        "EnableFirewall": ("Turns the firewall on or off.", "The same builder."),
        "SetNetworkSettings": ("Records the network configuration.", "The same builder."),
        "Build": ("Hands over the configuration assembled so far.",
                  "The configuration built by the preceding calls."),
    },
    "Creational/Builder/OperatingSystemConfigBuilder.cs": {
        "@type": "The concrete builder. It holds one configuration and fills it in as the "
                 "steps are called.",
        "OperatingSystemConfigBuilder": "Starts a new, empty configuration.",
        "SetOSName": ("Records the name of the operating system.", "The same builder."),
        "SetVersion": ("Records the version string.", "The same builder."),
        "SetFileSystem": ("Records the file system.", "The same builder."),
        "EnableFirewall": ("Turns the firewall on or off.", "The same builder."),
        "SetNetworkSettings": ("Records the network configuration.", "The same builder."),
        "Build": ("Hands over the configuration assembled so far.",
                  "The configuration built by the preceding calls."),
    },
    "Creational/Prototype/IPrototype.cs": {
        "@type": "A type that can produce a copy of itself.",
        "Clone": ("Produces a copy of this instance.", "A new instance carrying the same values."),
    },
    "Creational/Prototype/OperatingSystemSettings.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "Settings that are copied rather than rebuilt.",
        "OSName": "The name of the operating system.",
        "Version": "The version string.",
        "OperatingSystemSettings": "Creates the settings that later copies start from.",
        "Clone": ("Produces a copy of these settings.", "A new instance with the same values."),
        "DisplaySettings": "Writes the settings.",
    },

    # ---------------------------------------------------------------- structural
    "Structural/Adapter/ISystemInfo.cs": {
        "@type": "The interface the caller wants to work with.",
        "GetSystemDetails": ("Reports the system details in the shape the caller expects.",
                             "A description of the system."),
    },
    "Structural/Adapter/WindowsOS.cs": {
        "@type": "An existing class with its own interface, which the caller cannot change.",
        "RetrieveWindowsInfo": ("Reports the Windows details in its own shape.",
                                "A Windows specific description."),
    },
    "Structural/Adapter/LinuxOS.cs": {
        "@type": "An existing class with its own interface, which the caller cannot change.",
        "FetchLinuxInfo": ("Reports the Linux details in its own shape.",
                           "A Linux specific description."),
    },
    "Structural/Adapter/WindowsAdapter.cs": {
        "@type": "Presents WindowsOS through the interface the caller expects.",
        "WindowsAdapter": "Wraps the Windows implementation.",
        "GetSystemDetails": ("Translates the Windows call into the expected shape.",
                             "A description of the system."),
    },
    "Structural/Adapter/LinuxAdapter.cs": {
        "@type": "Presents LinuxOS through the interface the caller expects.",
        "LinuxAdapter": "Wraps the Linux implementation.",
        "GetSystemDetails": ("Translates the Linux call into the expected shape.",
                             "A description of the system."),
    },
    "Structural/Bridge/IFileSystem.cs": {
        "@type": "The implementation side of the bridge. It varies independently of the "
                 "abstraction that uses it.",
        "WriteToFile": "Writes the content to the named file.",
        "ReadFromFile": ("Reads the named file.", "The content of the file."),
    },
    "Structural/Bridge/WindowsFileSystem.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The Windows implementation behind the bridge.",
        "WriteToFile": "Writes the content the Windows way.",
        "ReadFromFile": ("Reads the file the Windows way.", "The content of the file."),
    },
    "Structural/Bridge/LinuxFileSystem.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The Linux implementation behind the bridge.",
        "WriteToFile": "Writes the content the Linux way.",
        "ReadFromFile": ("Reads the file the Linux way.", "The content of the file."),
    },
    "Structural/Bridge/FileManager.cs": {
        "@type": "The abstraction side of the bridge. It delegates every operation to an "
                 "IFileSystem, so the two hierarchies evolve separately.",
        "_fileSystem": "The implementation this abstraction delegates to.",
        "FileManager": "Binds the abstraction to an implementation.",
        "SaveFile": "Saves the content under the given name.",
        "ReadFile": ("Reads the named file.", "The content of the file."),
    },
    "Structural/Bridge/TextFileManager.cs": {
        "@type": "A refined abstraction that treats the content as text.",
        "TextFileManager": "Binds this manager to an implementation.",
        "SaveFile": "Saves the text content under the given name.",
        "ReadFile": ("Reads the named text file.", "The content of the file."),
    },
    "Structural/Composite/FileSystemComponent.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The common interface of a leaf and of a branch, so a client can treat "
                 "them the same way.",
        "Name": "The name of this component.",
        "FileSystemComponent": "Names the component.",
        "Display": "Writes this component, indented by the given depth.",
        "CalculateSize": ("Computes the size of this component.", "The size in bytes."),
    },
    "Structural/Composite/File.cs": {
        "@type": "A leaf of the tree. It has a size of its own and no children.",
        "File": "Creates a file of the given size.",
        "Display": "Writes the file name, indented by the given depth.",
        "CalculateSize": ("Reports the size of the file.", "The size in bytes."),
    },
    "Structural/Composite/Directory.cs": {
        "@type": "A branch of the tree. It answers the same calls as a leaf and forwards "
                 "them to its children.",
        "Directory": "Creates an empty directory with the given name.",
        "Add": "Adds a child component.",
        "Remove": "Removes a child component.",
        "Display": "Writes the directory and everything under it.",
        "CalculateSize": ("Adds up the size of every child.", "The total size in bytes."),
    },
    "Structural/Decorator/Notification.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The component that decorators wrap and that clients depend on.",
        "Send": "Sends the message.",
    },
    "Structural/Decorator/BasicNotification.cs": {
        "@type": "The undecorated component, which does the actual sending.",
        "Send": "Sends the message with no extra behaviour.",
    },
    "Structural/Decorator/NotificationDecorator.cs": {
        "@type": "The base of every decorator. It holds the wrapped notification and passes "
                 "the call along.",
        "_notification": "The notification this decorator wraps.",
        "NotificationDecorator": "Wraps another notification.",
    },
    "Structural/Decorator/LoggingDecorator.cs": {
        "@type": "Adds logging around the wrapped notification.",
        "LoggingDecorator": "Wraps another notification.",
        "Send": "Logs the message, then sends it.",
    },
    "Structural/Decorator/EncryptionDecorator.cs": {
        "@type": "Encrypts the message before the wrapped notification sends it.",
        "EncryptionDecorator": "Wraps another notification.",
        "Send": "Encrypts the message, then sends it.",
    },
    "Structural/Decorator/PrioritizationDecorator.cs": {
        "@type": "Marks the message as urgent before the wrapped notification sends it.",
        "PrioritizationDecorator": "Wraps another notification.",
        "Send": "Marks the message, then sends it.",
    },
    "Structural/Facade/FileValidator.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "One of the subsystem classes the facade hides.",
        "Validate": ("Checks that the path can be used.", "True when the path is usable."),
    },
    "Structural/Facade/FileReader.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "One of the subsystem classes the facade hides.",
        "ReadFile": ("Reads the file at the given path.", "The content of the file."),
    },
    "Structural/Facade/FileWriter.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "One of the subsystem classes the facade hides.",
        "WriteFile": "Writes the content to the given path.",
    },
    "Structural/Facade/FileManagerFacade.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "One entry point in front of the validator, the reader, and the writer.",
        "FileManagerFacade": "Creates the subsystem the facade drives.",
        "ProcessFile": "Validates the path, reads what is there, and writes the new content.",
    },
    "Structural/Flyweight/IFileMetadata.cs": {
        "@type": "The shared part of a file description, held once and reused.",
        "DisplayFileInfo": "Writes the shared metadata.",
    },
    "Structural/Flyweight/FileMetadata.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The flyweight. Its state is shared by every file with the same type and "
                 "owner, so it has to stay immutable.",
        "FileMetadata": "Creates the shared metadata for one type and owner pair.",
        "DisplayFileInfo": "Writes the shared metadata.",
    },
    "Structural/Flyweight/FileMetadataFactory.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "Hands out flyweights, creating one per distinct key and returning the "
                 "same instance for every later request.",
        "GetFileMetadata": ("Returns the metadata for this type and owner, creating it once.",
                            "The shared instance for the key."),
        "CacheCount": "How many distinct flyweights have been created.",
    },
    "Structural/Proxy/IResource.cs": {
        "@type": "The interface shared by the real resource and by its proxy.",
        "Access": "Uses the resource.",
    },
    "Structural/Proxy/Resource.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The real subject, which the proxy stands in for.",
        "Access": "Uses the resource for real.",
    },
    "Structural/Proxy/ResourceProxy.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "Stands in front of the real resource. It checks the role, and creates the "
                 "resource only when access is granted.",
        "ResourceProxy": "Creates a proxy that answers for the given role.",
        "Access": "Checks the role, then forwards to the real resource.",
    },

    # ---------------------------------------------------------------- behavioral
    "Behavioral/ChainOfResponsibility/FileOperationHandler.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "One link of the chain. Each handler either deals with the request or "
                 "passes it to the next one.",
        "_nextHandler": "The next handler in the chain, if there is one.",
        "SetNext": "Puts a handler after this one.",
        "HandleRequest": "Deals with the request, or passes it on.",
    },
    "Behavioral/ChainOfResponsibility/AuthorizationHandler.cs": {
        "@type": "Checks that the operation is allowed before anything else runs.",
        "HandleRequest": "Rejects a forbidden operation, otherwise passes the request on.",
    },
    "Behavioral/ChainOfResponsibility/ValidationHandler.cs": {
        "@type": "Checks that the request is well formed.",
        "HandleRequest": "Rejects an invalid request, otherwise passes it on.",
    },
    "Behavioral/ChainOfResponsibility/LoggingHandler.cs": {
        "@type": "Records the request at the end of the chain.",
        "HandleRequest": "Logs the request, then passes it on.",
    },
    "Behavioral/Command/ICommand.cs": {
        "@type": "A request captured as an object, so it can be stored and reversed.",
        "Execute": "Performs the request.",
        "Undo": "Reverses what Execute did.",
    },
    "Behavioral/Command/FileSystemReceiver.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The receiver. It knows how to do the work, and nothing about commands.",
        "CreateFile": "Creates the named file.",
        "WriteFile": "Writes the content to the named file.",
        "DeleteFile": "Deletes the named file.",
    },
    "Behavioral/Command/CreateFileCommand.cs": {
        "@type": "Captures a create request.",
        "CreateFileCommand": "Binds the request to a receiver and a file name.",
        "Execute": "Creates the file.",
        "Undo": "Deletes the file that Execute created.",
    },
    "Behavioral/Command/WriteFileCommand.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "Captures a write request.",
        "WriteFileCommand": "Binds the request to a receiver, a file name, and its content.",
        "Execute": "Writes the content.",
        "Undo": "Clears the content that Execute wrote.",
    },
    "Behavioral/Command/DeleteFileCommand.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "Captures a delete request.",
        "DeleteFileCommand": "Binds the request to a receiver and a file name.",
        "Execute": "Deletes the file.",
        "Undo": "Recreates the file that Execute deleted.",
    },
    "Behavioral/Command/FileInvoker.cs": {
        "@type": "Runs a command without knowing what it does or who carries it out.",
        "FileInvoker": "Binds the invoker to the command it will run.",
        "Execute": "Runs the command.",
        "Undo": "Reverses the command.",
    },
    "Behavioral/Interpreter/File.cs": {
        "@type": "The context an expression is interpreted against.",
        "Name": "The name of the file.",
        "Extension": "The extension of the file.",
        "File": "Creates the file description the filters read.",
    },
    "Behavioral/Interpreter/IExpression.cs": {
        "@type": "One rule of the grammar, able to decide whether a file matches.",
        "Interpret": ("Applies the rule to a file.", "True when the file matches the rule."),
    },
    "Behavioral/Interpreter/ExtensionFilter.cs": {
        "@type": "A terminal expression that matches on the extension.",
        "ExtensionFilter": "Creates a filter for one extension.",
        "Interpret": ("Checks the extension of the file.",
                      "True when the extension matches."),
    },
    "Behavioral/Interpreter/FilenameFilter.cs": {
        "@type": "A terminal expression that matches on the name.",
        "FilenameFilter": "Creates a filter for one name.",
        "Interpret": ("Checks the name of the file.", "True when the name matches."),
    },
    "Behavioral/Iterator/IIterator.cs": {
        "@type": "Walks a collection without exposing how the collection stores its items.",
        "HasNext": ("Reports whether anything is left.", "True when Next can be called."),
        "Next": ("Moves to the next item.", "The next item in the collection."),
    },
    "Behavioral/Iterator/IFileSystemCollection.cs": {
        "@type": "A collection that can hand out an iterator over itself.",
        "CreateIterator": ("Creates an iterator positioned before the first element.",
                           "A fresh iterator over this collection."),
    },
    "Behavioral/Iterator/IFileSystemElement.cs": {
        "@type": "An item a file system iterator can return.",
        "Name": "The name of the element.",
        "PrintDetails": "Writes a short description of the element.",
    },
    "Behavioral/Iterator/File.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "A file that an iterator can return.",
        "Name": "The name of the file.",
        "File": "Creates a named file.",
        "PrintDetails": "Writes a short description of the file.",
    },
    "Behavioral/Iterator/Directory.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "A directory that holds elements and hands out an iterator over them.",
        "Name": "The name of the directory.",
        "Directory": "Creates an empty directory with the given name.",
        "AddElement": "Adds an element to the directory.",
        "CreateIterator": ("Creates an iterator over the elements of this directory.",
                           "A fresh iterator."),
        "PrintDetails": "Writes a short description of the directory.",
    },
    "Behavioral/Mediator/IFileManager.cs": {
        "@type": "The mediator. Colleagues call it instead of calling one another.",
        "CreateFile": "Asks the handler to create the file.",
        "OpenFile": "Asks the handler to open the file.",
        "DeleteFile": "Asks the handler to delete the file.",
        "Notify": "Tells the mediator that something happened, so it can react.",
    },
    "Behavioral/Mediator/FileEvents.cs": {
        "@type": "The event codes the colleagues and the mediator exchange, declared once "
                 "so that a typo becomes a compile error.",
        "FileCreated": "Raised after a file has been created.",
        "FileOpened": "Raised after a file has been opened.",
        "FileDeleted": "Raised after a file has been deleted.",
    },
    "Behavioral/Mediator/FileManager.cs": {
        "@type": "The concrete mediator. It wires the colleagues together and holds every "
                 "rule about how they interact.",
        "FileManager": "Attaches every colleague to this mediator.",
        "CreateFile": "Forwards a create request to the handler.",
        "OpenFile": "Forwards an open request to the handler.",
        "DeleteFile": "Forwards a delete request to the handler.",
        "Notify": "Turns an event from a colleague into a log entry.",
    },
    "Behavioral/Mediator/FileExplorer.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "A colleague that selects a file and asks the mediator to act on it.",
        "CurrentFile": "The selected file, or null when nothing is selected.",
        "SetMediator": "Attaches this colleague to a mediator.",
        "SelectFile": "Selects the file that the next operation will act on.",
        "CreateFile": "Asks the mediator to create the selected file.",
        "OpenFile": "Asks the mediator to open the selected file.",
        "DeleteFile": "Asks the mediator to delete the selected file.",
    },
    "Behavioral/Mediator/FileOperationHandler.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "A colleague that performs the file operations the mediator asks for.",
        "Operations": "The operations performed so far, in order.",
        "IsAttached": "Whether a mediator has been attached.",
        "SetMediator": "Attaches this colleague to a mediator.",
        "CreateFile": "Performs a create operation.",
        "OpenFile": "Performs an open operation.",
        "DeleteFile": "Performs a delete operation.",
    },
    "Behavioral/Mediator/Logger.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "A colleague that records what the mediator reports.",
        "Entries": "The messages logged so far, in order.",
        "IsAttached": "Whether a mediator has been attached.",
        "SetMediator": "Attaches this colleague to a mediator.",
        "Log": "Records a message.",
    },
    "Behavioral/Memento/FileMemento.cs": {
        "@type": "A snapshot of the editor state. It carries the content and nothing else, "
                 "so the caretaker cannot reach into the originator.",
        "Content": "The content captured when the snapshot was taken.",
        "FileMemento": "Captures the given content.",
    },
    "Behavioral/Memento/FileEditor.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The originator. It produces snapshots of itself and restores from them.",
        "Content": "The content currently being edited.",
        "Write": "Replaces the content.",
        "Save": ("Takes a snapshot of the current content.", "A snapshot that can be restored."),
        "Restore": "Puts the editor back to the state held by the snapshot.",
    },
    "Behavioral/Memento/FileHistory.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The caretaker. It keeps snapshots on two stacks, one for undo and one "
                 "for redo, and never reads inside them.",
        "FileHistory": "Binds the history to the editor it will snapshot.",
        "Save": "Takes a snapshot and clears the redo history.",
        "Undo": "Goes back one step, keeping the current state for redo.",
        "Redo": "Goes forward one step, keeping the current state for undo.",
    },
    "Behavioral/Observer/IFileObserver.cs": {
        "@type": "Something that wants to hear about file changes.",
        "Update": "Called by the subject when a file has changed.",
    },
    "Behavioral/Observer/IFileSubject.cs": {
        "@type": "Something that reports file changes to its observers.",
        "RegisterObserver": "Starts sending notifications to this observer.",
        "UnregisterObserver": "Stops sending notifications to this observer.",
        "NotifyObservers": "Tells every registered observer about a change.",
    },
    "Behavioral/Observer/FileWatcher.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The concrete subject. It watches a directory and notifies its observers. "
                 "Events arrive on thread pool threads, so the observer list is guarded.",
        "RegisterObserver": "Starts sending notifications to this observer.",
        "UnregisterObserver": "Stops sending notifications to this observer.",
        "NotifyObservers": "Notifies a snapshot of the observers taken under the lock.",
        "StartWatching": "Starts watching a directory, replacing any earlier watch.",
        "StopWatching": "Stops watching and releases the underlying watcher.",
        "Dispose#": "Stops watching and releases everything this instance holds.",
        "Dispose#bool": "Releases the watcher when called from Dispose.",
    },
    "Behavioral/Observer/ConsoleLogger.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "An observer that writes each change.",
        "Update": "Writes the change.",
    },
    "Behavioral/Observer/EmailNotifier.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "An observer that stands in for sending an email about each change.",
        "Update": "Reports the change as an email would.",
    },
    "Behavioral/State/IFileState.cs": {
        "@type": "One state of the file, holding the behaviour that belongs to it and "
                 "deciding which state comes next.",
        "Open": "Handles an open request in this state.",
        "Close": "Handles a close request in this state.",
        "Edit": "Handles an edit request in this state.",
    },
    "Behavioral/State/FileContext.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "The context. It holds the current state and delegates every call to it.",
        "State": "The state the context is currently in.",
        "FileContext": "Starts the context in the created state.",
        "Open": "Delegates the open request to the current state.",
        "Close": "Delegates the close request to the current state.",
        "Edit": "Delegates the edit request to the current state.",
    },
    "Behavioral/State/CreatedState.cs": {
        "@type": "The state of a file that exists but has not been opened.",
        "Open": "Opens the file and moves the context to the opened state.",
        "Close": "Rejects the request, since the file was never opened.",
        "Edit": "Rejects the request, since the file is not open.",
    },
    "Behavioral/State/OpenedState.cs": {
        "@type": "The state of a file that is open and can be edited.",
        "Open": "Rejects the request, since the file is already open.",
        "Close": "Closes the file and moves the context to the closed state.",
        "Edit": "Edits the file.",
    },
    "Behavioral/State/ClosedState.cs": {
        "@type": "The state of a file that has been closed.",
        "Open": "Reopens the file and moves the context to the opened state.",
        "Close": "Rejects the request, since the file is already closed.",
        "Edit": "Rejects the request, since the file is closed.",
    },
    "Behavioral/Strategy/ICompressionStrategy.cs": {
        "@type": "One interchangeable compression algorithm.",
        "Compress": "Compresses the file at the given path.",
    },
    "Behavioral/Strategy/ZipCompressionStrategy.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "Compresses using the zip format.",
        "Compress": "Compresses the file as a zip archive.",
    },
    "Behavioral/Strategy/GZipCompressionStrategy.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "Compresses using the gzip format.",
        "Compress": "Compresses the file with gzip.",
    },
    "Behavioral/Strategy/FileCompressor.cs": {
        "@type": "The context. It compresses through whichever strategy is set, and can "
                 "swap that strategy at run time.",
        "SetCompressionStrategy": "Chooses the algorithm used from now on.",
        "CompressFile": "Compresses the file with the current strategy.",
    },
    "Behavioral/TemplateMethod/FileProcessor.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "Fixes the order of the processing steps and leaves the steps themselves "
                 "to the subclasses.",
        "ProcessFile": "Runs the four steps in the order this class defines.",
        "OpenFile": "Opens the file. Subclasses extend this to create their reader.",
        "ReadFileContent": ("Reads the content of the file.", "Everything the file holds."),
        "ProcessContent": "Does whatever this processor does with the content.",
        "CloseFile": "Releases whatever OpenFile acquired.",
    },
    "Behavioral/TemplateMethod/TextFileProcessor.cs": {
        "@type": "Processes a text file by upper casing its content.",
        "OpenFile": "Opens a reader over the file.",
        "ReadFileContent": ("Reads the whole file.", "The text the file holds."),
        "ProcessContent": "Upper cases the text.",
        "CloseFile": "Disposes the reader.",
    },
    "Behavioral/TemplateMethod/CsvFileProcessor.cs": {
        "@type": "Processes a CSV file line by line.",
        "OpenFile": "Opens a reader over the file.",
        "ReadFileContent": ("Reads the whole file.", "The text the file holds."),
        "ProcessContent": "Splits the text into lines and columns.",
        "CloseFile": "Disposes the reader.",
    },
    "Behavioral/Visitor/IFileSystemElement.cs": {
        "@type": "An element that accepts a visitor. Adding an operation means adding a "
                 "visitor, not changing this type.",
        "Accept": "Lets the visitor operate on this element.",
    },
    "Behavioral/Visitor/IFileSystemVisitor.cs": {
        "@type": "One operation over the whole element structure.",
        "Visit#File": "Operates on a file.",
        "Visit#Directory": "Operates on a directory.",
    },
    "Behavioral/Visitor/File.cs": {
        "@type": "A file element that a visitor can operate on.",
        "Name": "The name of the file.",
        "Size": "The size of the file in bytes.",
        "File": "Creates a file of the given size.",
        "Accept": "Sends this file to the visitor.",
    },
    "Behavioral/Visitor/Directory.cs": {
        "@type": "A directory element that a visitor can operate on.",
        "Name": "The name of the directory.",
        "Elements": "The elements this directory holds.",
        "Directory": "Creates an empty directory with the given name.",
        "AddElement": "Adds an element to the directory.",
        "Accept": "Sends this directory to the visitor.",
    },
    "Behavioral/Visitor/FileListingVisitor.cs": {
        "Output": OUTPUT_SUMMARY,
        "@type": "A visitor that writes the name of everything it walks.",
        "Visit#File": "Writes the name of the file.",
        "Visit#Directory": "Writes the name of the directory and walks into it.",
    },
    "Behavioral/Visitor/SizeCalculationVisitor.cs": {
        "@type": "A visitor that adds up the size of everything it walks.",
        "TotalSize": "The size accumulated so far.",
        "Visit#File": "Adds the size of the file to the total.",
        "Visit#Directory": "Walks into the directory.",
    },
}
