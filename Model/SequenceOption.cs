namespace WebApplication1.Model
{
    public class SequenceOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cmd { get; set; }
        public bool Checked { get; set; }
        /// <summary>
        /// -1=false 0 初始状态  1 pass
        /// </summary>
        public int Result { get; set; }
    }
}
