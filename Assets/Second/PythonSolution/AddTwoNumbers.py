class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

# 注意：python中新建一个对象不需要new关键字，直接使用类名即可 
#      python中的逻辑运算符是 and or not
class Solution:
    def addTwoNumbers(self, l1: ListNode, l2: ListNode) -> ListNode:
        temp = 0
        root = ListNode(0)
        node = root
        while (l1 or l2 or temp):
            if(l1):
                temp += l1.val
                l1 = l1.next
            if(l2):
                temp += l2.val
                l2 = l2.next
            node.next = ListNode(temp % 10)
            node = node.next
            temp = temp // 10
        return root.next