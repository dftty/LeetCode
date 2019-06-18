class Solution:

    # 我的解法
    # 使用回溯递归判断是否存在,代码臃肿
    # 在使用python写解决方案的时候，刚开始并没有使用and来判断，而是使用&符号，这是错误的。
    def exist(self, board, word: str) -> bool:
        def check(coorset, temp_board, start_x, start_y, temp_word):
            result = False
            if((start_x, start_y) in coorset):
                return result
            if(temp_board[start_x][start_y] != temp_word[len(coorset)]):
                return result
            coorset.add((start_x, start_y))
            if(len(coorset) == len(temp_word)):
                result = True
                return result
            if((not result) and start_x + 1 < len(temp_board)):
                result |= check(coorset, temp_board, start_x + 1, start_y, temp_word)
            if((not result) and start_y + 1 < len(temp_board[0])):
                result |= check(coorset, temp_board, start_x, start_y + 1, temp_word)
            if((not result) and start_x - 1 >= 0):
                result |= check(coorset, temp_board, start_x - 1, start_y, temp_word)
            if((not result) and start_y - 1 >= 0):
                result |= check(coorset, temp_board, start_x, start_y - 1, temp_word)
                
            coorset.remove((start_x, start_y))
            return result
            
        for i in range(len(board)):
            for j in range(len(board[0])):
                if(board[i][j] == word[0]):
                    result = check(set(), board, i, j, word)
                    if(result):
                        return result
                    
        return False

    
    # solution解法 没有使用set进行判断
    def exist_solution(self, board, word: str) -> bool:
        m = len(board)
        n = len(board[0])
        def dfs(board, start_x, start_y, word, depth):
            result = False
            if(start_x < 0 or start_y < 0 or start_x >= m or start_y >= n):
                return result
            if(board[start_x][start_y] != word[depth]):
                return result
            if(len(word) == depth + 1):
                return True
            
            temp_ch = board[start_x][start_y]
            board[start_x][start_y] = '#'
            result |= dfs(board, start_x + 1, start_y, word, depth + 1) \
                    | dfs(board, start_x - 1, start_y, word, depth + 1) \
                    | dfs(board, start_x, start_y + 1, word, depth + 1) \
                    | dfs(board, start_x, start_y - 1, word, depth + 1) \

            board[start_x][start_y] = temp_ch

            return result

        for i in range(m):
            for j in range(n):
                if(board[i][j] == word[0] and dfs(board, i, j, word, 0)):
                    return True
    