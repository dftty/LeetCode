class Solution:
    def findSubstring(self, s: str, words):
        if not words:
            return []
        count = {}
        for i in range(len(words)):
            count[words[i]] = count.get(words[i], 0) + 1
        
        wordsLen = len(words)
        wordLen = len(words[0])
        res = []
        for i in range(len(s) - wordsLen * wordLen + 1):
            dic = {}
            j = 0
            while(j < wordsLen):
                subS = s[i + j * wordLen : i + (j + 1) * wordLen]
                dic[subS] = dic.get(subS, 0) + 1
                if(dic[subS] > count.get(subS, 0)):
                    break
                j += 1
            if j == wordsLen:
                res.append(i)
        return res