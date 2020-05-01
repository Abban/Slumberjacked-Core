namespace BBX.Main.Save.Interfaces
{
    public interface IDataRepository<T> where T : class
    {
        /// <summary>
        /// save the data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filename"></param>
        void Save(T data, string filename);


        /// <summary>
        /// Load the data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        void Load(T data, string filename);
        
        
        /// <summary>
        /// Does the data exist
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        bool Exists(string filename);
        
        
        /// <summary>
        /// Delete the data
        /// </summary>
        /// <param name="filename"></param>
        void Delete(string filename);
    }
}