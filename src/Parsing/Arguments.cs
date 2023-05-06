namespace PixelsSorted.Parsing
{
    public class Arguments
    {
        public bool invalid;
        public string path;
        public SortDirection sortDirection;
        public SortOrder sortMode;
        public SortValue sortValue;
        public Arguments(string path)
        {
            this.path = path;
        }
    }
    public enum SortDirection
    {
        Vertical,
        Horizontal
    }
    public enum SortOrder
    {
        SmallestToLargest,
        LargestToSmallest
    }
    public enum SortValue
    {
        Hue,
        Saturation,
        Brightness
    }
}
