class Solution:
    def longestPalindrome(self, s: str) -> str:
        length = len(s)
        dp = [[False] * length for i in range(length)]
        
        start = 0
        index = 0
        # range 左闭右开
        for i in range(length - 1, -1, -1):
            for j in range(i, length):
                dp[i][j] = s[i] == s[j] and (j - i < 2 or dp[i + 1][j - 1])
                
                if(dp[i][j] and j - i + 1 > index):
                    start = i
                    index = j - i + 1
        index = start + index

        
        # 字符串截取
        return s[start : index]