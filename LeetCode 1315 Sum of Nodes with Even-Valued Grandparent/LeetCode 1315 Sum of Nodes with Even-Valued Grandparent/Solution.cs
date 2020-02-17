namespace LeetCode_1315_Sum_of_Nodes_with_Even_Valued_Grandparent
{
    public class Solution
    {
        // returns an int with the sum of values of nodes with even-valued grandparents
        public int SumEvenGrandparent(TreeNode root)
        {
            // Create a counter to keep track of the sum
            int count = 0;
            // For every node, check if even
            count += isEven(root.val)
                // if even, count grandchildren and add to count
                ? countGrandchildren(root)
                : 0;
            // Traverse left
            if (root.left != null)
            {
                count += SumEvenGrandparent(root.left);
            }

            // Traverse right
            if (root.right != null)
            {
                count += SumEvenGrandparent(root.right);
            }

            return count;
        }

        protected bool isEven(int val) => val % 2 == 0;

        protected int countGrandchildren(TreeNode node) => countChildren(node.left) + countChildren(node.right);

        protected int countChildren(TreeNode node)
        {
            if (node != null)
            {
                int count = node.left != null ? node.left.val : 0;
                return count + (node.right != null ? node.right.val : 0);
            }

            return 0;
        }

    }
}
