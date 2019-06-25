class Solution:
    def longestCommonPrefix(self, strs) -> str:
        if(not strs or len(strs) == 0):
            return ''
        res = strs[0]
        for i in range(len(strs)):
            fi = 0
            se = 0
            
            while(fi < len(res) and se < len(strs[i]) and res[fi] == strs[i][se]):
                fi += 1
                se += 1
                
            if(fi < se):
                res = res[0: fi]
            else:
                res = strs[i][0:se]
        return res
    # https://www.runoob.com/python/python-func-zip.html
    # zip函数使用方法
    # 对于 ["dog","race","car"] 数组，调用zip方法后如下
    # [('d', 'r', 'c'), ('o', 'a'), ('g', 'c', 'r'), ('e')]
    #
    def longestCommonPrefix_(self, strs):
        """
        :type strs: List[str]; rtype: str
        """
        sz, ret = zip(*strs), ""
        # looping corrected based on @StefanPochmann's comment below
        for c in sz:
            if len(set(c)) > 1: break
            ret += c[0]
        return ret