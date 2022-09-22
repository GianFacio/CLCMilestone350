namespace CLCMilestone.Models
{
    public class CellModel
    {
		// From original minesweeper
		public int row { get; set; }
		public int column { get; set; }
		public int neighbors { get; set; }
		public bool live { get; set; }
		public bool visited { get; set; }
        public bool flag { get; set; }

        public CellModel(int r, int c, int n, bool l, bool v, bool f)
		{
			row = r;
			column = c;
			neighbors = n;
			live = l;
			visited = v;
			flag = f;
		}

        public CellModel()
        {

        }
    }
}
