﻿/// <reference path="../../../build/linq.d.ts"/>

namespace Math2D {

    /**
     * ##### An Algorithm for Creating and Selecting Graph Axes
     * 
     * > http://austinclemens.com/blog/2016/01/09/an-algorithm-for-creating-a-graphs-axes/
    */
    export function NiceAxisTicks(min: number, max: number, nTicks: number = 10, decimalDigits: number = 2): number[] {

        // First, get the minimum and maximum of the series, toggle the zero_flag variable 
        // if 0 Is between Then the min And max, And Get the range Of the data.
        var zeroFlag: boolean = false;
        var range: number = max - min;
        var inputRange = new data.NumericRange(min, max);

        if ((min == max) && (min + max != 0)) {
            return [0, max];
        }

        if (range == 0) {
            return [];
        }

        if (min <= 0 && max >= 0) {
            zeroFlag = true;
        }

        // Next, define ‘nice’ numbers. You could change this if you’d like to include other 
        // possibilities, but I decided I would allow counting by 
        // 1s, 2s, 5s, 10s, 15s, 25s, and 75s. This will make a bit more sense below.
        var niceTicks: number[] = [0.1, 0.2, 0.5, 1, 0.15, 0.25, 0.75];

        // This next part is a bit of path dependence – I had an algorithm where the number of 
        // ticks was more central and I kept that framework but I probably wouldn’t do it this 
        // way again. I get a naive value for the distance between ticks and determine the place 
        // value of this distance.
        var steps: number = range / (nTicks - 1);
        var rounded: number;
        var digits: number;

        if (steps >= 1) {
            rounded = Math.round(steps);
            digits = rounded.toString().length;
        } else {
            var places = steps.toString().split(".")[1];
            var firstPlace: number = 0;

            for (var i: number = 0; i < places.length; i++) {
                if (places[i] != "0" && firstPlace == 0) {
                    firstPlace = i;
                    break;
                }
            }

            digits = -firstPlace
        }

        // Now using the value of digits (the place value of steps), generate a list of candidate steps. 
        // These are just the values from nice_steps above multiplied by powers of 10 according to the 
        // place value of digits. Because computation doesn’t matter to me, 
        // I check 10^place value+1, 10^place value, and 10^place value-1. Most of these candidate step 
        // lengths will be terrible but it doesn’t matter – they will get weeded out in the next step. 
        // If our initial step length was 13, candidate steps will be generated by taking 1, 10 and 100 * all values 
        // of nice_ticks. So 13 would result in candidate steps: 
        // [.1,.2,.5,1,.15,.25,.75,1,2,5,10,2.5,2.5,7.5,20,50,100,15,25,75]
        var candidateSteps = new List<number>();

        for (var i: number = 0; i < niceTicks.length; i++) {
            candidateSteps.Add(niceTicks[i] * Math.pow(10, digits));
            candidateSteps.Add(niceTicks[i] * Math.pow(10, digits - 1));
            candidateSteps.Add(niceTicks[i] * Math.pow(10, digits + 1));
        }

        var minSteps: number;
        var stepArray = new List<number>();
        var candidateArray = new List<List<number>>();

        // Loop through candidate steps and generate an axis based on each step length.
        for (var i: number = 0; i < candidateSteps.Count; i++) {
            steps = candidateSteps[i];

            // starting value depends on whether Or Not 0 Is in the array
            if (zeroFlag) {
                minSteps = Math.ceil(Math.abs(min) / steps);
                stepArray = new List<number>([- minSteps * steps]);
            } else {
                stepArray = new List<number>([Math.floor(min / steps) * steps]);
            }

            var stepnum = 1;

            while (stepArray[stepArray.Count - 1] < max) {
                stepArray.Add((stepArray[0] + steps * stepnum));
                stepnum += 1;
            }

            // this arbitrarily enforces step_arrays of length between 4 And 10

            // 2017-9-12 假若在这里直接使用个数来限制最终的结果的话，很可能会出现candidateArray为空的情况
            // 所以为了避免出现这个问题，在这里就不进行限制了，直接添加结果到候选的数据集之中
            // If (stepArray.Count < 11 AndAlso stepArray.Count > 4) Then

            // All that remains is to score all the candidate arrays. 
            // I’m not going to include my scorer, because there are a 
            // lot of arbitrary choices involved, but basically I look at 
            // how much space each array wastes compared to the data use 
            // that as a starting value. Each array gets the score 10^percent 
            // wasted space – then I further penalize the array for large 
            // values of ticks, tick values that I don’t like as much 
            // (.15 for example, is great in certain cases, but probably 
            // shouldn’t be liked as much by the function as .1). 
            // The array with the lowest score ‘wins’.
            candidateArray.Add(stepArray);
            // End If
        }

        // 通过分别计算ticks的数量差值，是否容纳了输入的[min,max]范围来判断是否合适
        var maxSteps = new MathV.Vector(candidateArray.Max(candidate => candidate.Count));
        var dSteps: MathV.Vector = maxSteps.Subtract(candidateArray.Select(candidate => Math.abs(candidate.Count - nTicks)));
        var dMin: MathV.Vector = MathV.Subtract(inputRange.Length, candidateArray.Select(candidate => Math.abs(candidate.Min() - inputRange.min)));
        var dMax: MathV.Vector = MathV.Subtract(inputRange.Length, candidateArray.Select(candidate => Math.abs(candidate.Max() - inputRange.max)));

        dSteps = dSteps.Divide(dSteps.Max());
        dMin = dMin.Divide(dMin.Max());
        dMax = dMax.Divide(dMax.Max());

        var scores = (dSteps.Multiply(0.8)).Add(dMin.Multiply(0.1)).Add(dMax.Multiply(0.1));
        var ticks: number[] = candidateArray[Which.Max(scores)];

        // 2018-2-1
        // 如果数值是 1E-10 这样子的小数的话，在这里直接使用Round或导致返回的ticks全部都是零的bugs
        // 在这里加个开关，如果小于零就不在进行round了
        if (decimalDigits >= 0) {
            for (var i: number = 0; i < ticks.length; i++) {
                ticks[i] = parseFloat(ticks[i].toFixed(decimalDigits));
            }
        }

        return ticks;
    }
}