--https://www.acmicpc.net/problem/11054

function string:splitNumber(sep)
    if sep == nil then
        sep = "%s"
    end

    local t = {}
    for str in string.gmatch(self, "([^"..sep.."]+)") do
        table.insert(t, tonumber(str))
    end
    return t
end

local arraySize = tonumber(io.read())
local array = io.read():splitNumber(' ')

local result = 0
local t = {}
local reverseT = {}
for i = 1, arraySize do
    t[i] = 1
    reverseT[i] = 1
end

for i = 2, arraySize do
    local iReverseIdx = arraySize - i + 1
    for j = 1, i do
        if array[i] > array[j] and t[i] < t[j] + 1 then
            t[i] = t[j] + 1
        end

        local jReverseIdx = arraySize - j + 1
        if array[iReverseIdx] > array[jReverseIdx] and reverseT[iReverseIdx] < reverseT[jReverseIdx] + 1 then
            reverseT[iReverseIdx] = reverseT[jReverseIdx] + 1
        end
    end
end

for i = 1, arraySize do
    local sum = t[i] + reverseT[i] - 1
    if result < sum then
        result = sum
    end
end

print(result)