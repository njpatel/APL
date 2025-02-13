---
title: percentile_tdigest() - Azure Data Explorer
description: This article describes percentile_tdigest() in Azure Data Explorer.
services: data-explorer
author: orspod
ms.author: orspodek
ms.reviewer: alexans
ms.service: data-explorer
ms.topic: reference
ms.date: 12/10/2019
---
# percentile_tdigest()

Calculates the percentile result from the `tdigest` results (which was generated by [tdigest()](tdigest-aggfunction.md) or [tdigest_merge()](tdigest-merge-aggfunction.md))

## Syntax

`percentile_tdigest(`*`Expr`*`,` *Percentile1* [`,` *typeLiteral*]`)`

`percentiles_array_tdigest(`*`Expr`*`,` *Percentile1* [`,` *Percentile2*] ...[`,` *PercentileN*]`)`

`percentiles_array_tdigest(`*`Expr`*`,` *Dynamic array*`)`

## Arguments

* *Expr*: Expression that was generated by [`tdigest`](tdigest-aggfunction.md) or [tdigest_merge()](tdigest-merge-aggfunction.md).
* *Percentile* is a double constant that specifies the percentile.
* *typeLiteral*: An optional type literal (for example, `typeof(long)`). If provided, the result set will be of this type. 
* *Dynamic array*: list of percentiles in a dynamic array of integer or floating point numbers.

## Returns

The percentiles/percentilesw value of each value in *`Expr`*.

**Tips**

* The function must receive at least one percent (and maybe more, see the syntax above: *Percentile1* [`,` *Percentile2*] ...[`,` *PercentileN*]) and the result will be
  a dynamic array that includes the results. (such like [`percentiles()`](percentiles-aggfunction.md))
  
* If only one percent was provided, and the type was provided also, then the result will be a column of the same type provided with the results of that percent. In this case, all `tdigest` functions must be of that type.

* If *`Expr`* includes `tdigest` functions of different types, don't provide the type. The result will be of type dynamic. See below examples.

## Examples

<!-- csl: https://help.apl.windows.net:443/Samples -->
```apl
StormEvents
| summarize tdigestRes = tdigest(DamageProperty) by State
| project percentile_tdigest(tdigestRes, 100, typeof(int))
```

|percentile_tdigest_tdigestRes|
|---|
|0|
|62000000|
|110000000|
|1200000|
|250000|

<!-- csl: https://help.apl.windows.net:443/Samples -->
```apl
StormEvents
| summarize tdigestRes = tdigest(DamageProperty) by State
| project percentiles_array_tdigest(tdigestRes, range(0, 100, 50), typeof(int))
```

|percentile_tdigest_tdigestRes|
|---|
|[0,0,0]|
|[0,0,62000000]|
|[0,0,110000000]|
|[0,0,1200000]|
|[0,0,250000]|

<!-- csl: https://help.apl.windows.net:443/Samples -->
```apl
StormEvents
| summarize tdigestRes = tdigest(DamageProperty) by State
| union (StormEvents | summarize tdigestRes = tdigest(EndTime) by State)
| project percentile_tdigest(tdigestRes, 100)
```

|percentile_tdigest_tdigestRes|
|---|
|[0]|
|[62000000]|
|["2007-12-20T11:30:00.0000000Z"]|
|["2007-12-31T23:59:00.0000000Z"]|
