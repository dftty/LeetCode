class Solution:
    def majorityElement(self, nums) -> int:
        # 字典这样初始化
        dic = {}
        for i in range(len(nums)):
            dic[nums[i]] = dic.get(nums[i], 0) + 1
        for num in nums:
            if(dic[num] > len(nums) // 2):
                return num