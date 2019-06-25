class Solution:
    def carPooling(self, trips, capacity: int) -> bool:
        events = []
        for i in range(len(trips)):
            events.append([trips[1], trips[0]])
            events.append([trips[2], -trips[0]])

        people = 0
        events.sort()

        for i in range(len(events)):
            people += events[i][1]

            if(people > capacity):
                return False
        return True