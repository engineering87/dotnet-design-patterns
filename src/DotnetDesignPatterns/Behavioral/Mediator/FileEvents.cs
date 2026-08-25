// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Mediator
{
    // The event codes exchanged between the colleagues and the mediator.
    // They are declared once instead of being repeated as string literals,
    // so that a typo becomes a compile error rather than a silent no-op.
    /// <summary>
    /// The event codes the colleagues and the mediator exchange, declared once so that a typo becomes a compile error.
    /// </summary>
    public static class FileEvents
    {
        /// <summary>
        /// Raised after a file has been created.
        /// </summary>
        public const string FileCreated = "FileCreated";

        /// <summary>
        /// Raised after a file has been opened.
        /// </summary>
        public const string FileOpened = "FileOpened";

        /// <summary>
        /// Raised after a file has been deleted.
        /// </summary>
        public const string FileDeleted = "FileDeleted";
    }
}
