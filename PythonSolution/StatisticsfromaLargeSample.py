import bisect

class Solution:
    def sampleStats(self, count):
        result = [0] * 5
        totalCount = 0
        s = 0
        singleMax = 0
        for i in range(len(count)):
            if(result[0] == 0 and count[i] != 0 and i != 0):
                result[0] = i / 1
            
            if(count[i] != 0):
                result[1] = i / 1
                totalCount += count[i]
                s = s + i * count[i]
                
                if(count[i] > singleMax):
                    result[4] = i / 1
                    singleMax = count[i]
        
        if(count[0] != 0):
            result[0] = 0 / 1
        
        result[2] = s / totalCount
        isOdd = totalCount % 2 != 0
        middleIndex = totalCount // 2
        currentCount = 0
        
        for i in range(len(count)):
            currentCount += count[i]
            
            if(isOdd and currentCount >= middleIndex):
                result[3] = i / 1
                return result
            elif(not isOdd and currentCount > middleIndex and result[3] == 0):
                result[3] = i / 1
                return result
            elif(not isOdd and currentCount == middleIndex and result[3] == 0):
                result[3] += i
            elif(not isOdd and result[3] != 0 and count[i] != 0):
                result[3] += i
                result[3] = result[3] / 2
                return result
            
        return result

    def sampleStats_2(self, count):
        n = sum(count)
        mi = next(i for i in range(256) if count[i]) * 1.0
        ma = next(i for i in range(255, -1, -1) if count[i]) * 1.0
        mean = sum(i * v for i, v in enumerate(count)) * 1.0 / n
        mode = count.index(max(count)) * 1.0
        for i in range(255):
            count[i + 1] += count[i]
        median1 = bisect.bisect(count, (n - 1) / 2)
        median2 = bisect.bisect(count, n / 2)
        median = (median1 + median2) / 2.0
        return [mi, ma, mean, median, mode]