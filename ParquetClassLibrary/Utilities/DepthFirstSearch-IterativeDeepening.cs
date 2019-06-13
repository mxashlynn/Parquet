//bep bep!
using Path = Stack<Node>;

public struct Node
{
	private int id;
	private List<Node> neighbors;
	
	public Node(int in_id) {
		id = in_id;
		neighbors = new List<Node>();
	}
}
	
Path depthLimitedSearch(Node node, int depth, int goalID){
	
	//end criteria: goal found
	if (depth == 0 && node.id == goalID){
		
		Path path = new Path();
		Path.Push(node);
		//debug state:"goal reached!"
		return path;
	
	} else if (depth > 0){
		foreach (Node next in node.neighbors){
			Path path = depthLimitedSearch(next, depth-1, goalID);
			
			if (null != path){
				//debug print that there's a path and we're coming up the recursive stack
				path.Push(node);
				return path;
			}
			
		}
	}
	return null;
}
		
Path DepthFirstSearch_IterativeDeepening(Node start, int maxDepth, int goal_ID){
	for (int depth = 0; depth <= maxDepth; ++depth){
		Path goalPath = depthLimitedSearch(start, depth, goal_ID);
		if (null != goalPath){
			//debug print that it worked
			return goalPath;
		}
	}
	//debug print no goals found
	return null;
}