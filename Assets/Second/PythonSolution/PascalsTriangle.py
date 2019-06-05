class Solution:
    def generate(self, numRows: int):
        result = []
        if not numRows:
            return result
        
        for i in range(1, numRows + 1):
            temp = [1] * i
            lo = 1
            hi = i - 2
            while lo <= hi:
                temp[lo] = temp[hi] = result[i - 2][lo] + result[i - 2][lo - 1]
                lo += 1
                hi -= 1
            result.append(temp)
        return result