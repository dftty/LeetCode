class Solution:
    def gardenNoAdj(self, N: int, paths):
        res = [0] * N
        G = [[] for i in range(N)]
        for x, y in paths:
            G[x - 1].append(y - 1)
            G[y - 1].append(x - 1)
        for i in range(N + 1):
            res[i - 1] = ({1, 2, 3, 4} - {res[j] for j in G[i - 1]}).pop()
        return res