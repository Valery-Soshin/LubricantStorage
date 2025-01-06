namespace LubricantStorage.Core
{
    /// <summary>
    /// Общие поля для всех сущностей
    /// </summary>
    public interface IEntityCommon
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset CreateDate { get; set; }
    }
}