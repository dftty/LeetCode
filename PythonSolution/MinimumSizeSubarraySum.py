import math

class Solution:
    def mintotalbArrayLen(self, s: int, nums) -> int:
        if not nums:
            return 0
        i = 0
        total = 0
        start = 0
        res = math.inf
        while(i < len(nums)):
            total += nums[i]
            print(total)
            while(total >= s and start <= i):
                res = min(res, i - start + 1)
                total -= nums[start]
                start += 1
            i += 1
                
        return 0 if res == math.inf else res
        