namespace BBX.Main.Save.Interfaces
{
    public interface IDataRepository<T> where T : class
    {
        /// <summary>
        /// save the data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        void Save(T data, string fileName);


        /// <summary>
        /// Load the data
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        T Load(string fileName);
        
        
        /// <summary>
        /// Does the data exist
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool Exists(string fileName);
        
        
        /// <summary>
        /// Delete the data
        /// </summary>
        /// <param name="fileName"></param>
        void Delete(string fileName);
    }
}