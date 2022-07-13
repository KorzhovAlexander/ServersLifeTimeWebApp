namespace ServersLifeTimeWebApp;

public static class MergeExtenstion
{
    public static IEnumerable<DateTime[]> Merge(this DateTime[][] intervals)
    {
        if (intervals == null || intervals.Length == 0) return Array.Empty<DateTime[]>();

        Array.Sort(intervals, 0, intervals.Length, new IntervalComparer());
        var stack = new Stack<DateTime[]>();

        var curr = intervals[0];

        for (var i = 1; i < intervals.Length; i++)
        {
            var next = intervals[i];
            if (curr[1] >= next[0])
                curr = new DateTime[] {curr[0], curr[1] > next[1] ? curr[1] : next[1]};
            else
            {
                stack.Push(curr);
                curr = next;
            }
        }

        stack.Push(curr);

        var ret = new DateTime[stack.Count][];
        for (var i = ret.Length - 1; i >= 0; i--)
            ret[i] = stack.Pop();

        return ret;
    }

    private class IntervalComparer : IComparer<DateTime[]>
    {
        public int Compare(DateTime[] x, DateTime[] y)
        {
            return x[0].CompareTo(y[0]);
        }
    }
}
