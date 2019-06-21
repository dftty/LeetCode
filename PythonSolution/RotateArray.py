class Solution:

    def rotate(self, nums, k: int) -> None:
        """
        Do not return anything, modify nums in-place instead.
        """
        def transpose(nums, lo, hi):
            if(lo > hi):
                return
            
            while(lo < hi):
                nums[lo], nums[hi] = nums[hi], nums[lo]
                lo += 1
                hi -= 1
        k = k % len(nums)
        transpose(nums, 0, len(nums) - 1)
        transpose(nums, 0, k - 1)
        transpose(nums, k, len(nums) - 1)
    