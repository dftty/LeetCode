import math

class Solution:
    def shortestPathBinaryMatrix(self, grid) -> int:
        m = len(grid)
        n = len(grid[0])
        
        if(grid[0][0] == 1 or grid[-1][-1] == 1):
            return -1
        queue = []
        queue.append([0, 0])
        grid[0][0] = 1
        res = 0
        while(len(queue) > 0):
            size = len(queue)
            res = res + 1
            for i in range(size):
                temp = queue.pop(0)
                if(temp[0] == m - 1 and temp[1] == n - 1):
                    return res
                
                for j in range(-1, 2):
                    for k in range(-1, 2):
                        coor = [temp[0] + j, temp[1] + k]
                        if(coor[0] >= 0 and coor[1] >= 0 and coor[0] < m and coor[1] < n and grid[coor[0]][coor[1]] == 0):
                            queue.append(coor)
                            grid[coor[0]][coor[1]] = 1  
        return -1

    def shortestPathBinaryMatrix_(self, grid) -> int:
        n = len(grid)
        if(grid[0][0] or grid[-1][-1]):
            return -1
        q = [(0, 0, 1)]

        # 创建多维数组的方法
        ds = [[math.inf] * n for i in range(n)]

        # for循环迭代
        for i, j, d in q:
            if i == n - 1 and j == n - 1:
                return d
            for m in range(-1, 2):
                for l in range(-1, 2):
                    coor = [m + i, l + j]
                    if(0 <= coor[0] < n and 0 <= coor[1] < n and not grid[coor[0]][coor[1]]):
                        grid[coor[0]][coor[1]] = 1
                        q.append((coor[0], coor[1], d + 1))
        
        return -1