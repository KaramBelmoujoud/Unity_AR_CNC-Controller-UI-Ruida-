using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTransfer : MonoBehaviour
{
    [HideInInspector]
    public string Left = @"[
  {
            'data.data': '02:61:d4:89:0d:f7',
    'data.len': '6'
  },
  {
            'data.data': '02:61:d4:89:0d:f7',
    'data.len': '6'
  },
  {
            'data.data': '02:95:d4:89:89:af',
    'data.len': '6'
  },
  {
            'data.data': '02:a5:d4:89:89:bf',
    'data.len': '6'
  },
  {
            'data.data': '02:73:d4:89:89:8d',
    'data.len': '6'
  },
  {
            'data.data': '02:7d:d4:89:89:97',
    'data.len': '6'
  },
  {
            'data.data': '02:61:d4:89:0d:f7',
    'data.len': '6'
  },
  {
            'data.data': '02:73:d4:89:8d:89',
    'data.len': '6'
  },
  {
            'data.data': '02:0f:d4:89:89:29',
    'data.len': '6'
  },
  {
            'data.data': '02:1f:d4:89:89:39',
    'data.len': '6'
  },
  {
            'data.data': '01:f3:d4:0d:89:89',
    'data.len': '6'
  },
  {
            'data.data': '02:61:d4:89:0d:f7',
    'data.len': '6'
  },
  {
            'data.data': '02:61:d4:89:0d:f7',
    'data.len': '6'
  },
  {
            'data.data': '02:95:d4:89:89:af',
    'data.len': '6'
  },
  {
            'data.data': '02:a5:d4:89:89:bf',
    'data.len': '6'
  },
  {
            'data.data': '02:73:d4:89:89:8d',
    'data.len': '6'
  },
  {
            'data.data': '02:7d:d4:89:89:97',
    'data.len': '6'
  },
  {
            'data.data': '02:8f:d4:89:89:a9',
    'data.len': '6'
  },
  {
            'data.data': '03:b0:42:8b:89:89:0b:dd:e9',
    'data.len': '9'
  },
  {
            'data.data': '01:eb:d0:09:89:89',
    'data.len': '6'
  },
  {
            'data.data': '02:6d:d0:8b:89:89',
    'data.len': '6'
  },
  {
            'data.data': '02:0b:d0:29:89:89',
    'data.len': '6'
  },
  {
            'data.data': '02:8d:d0:ab:89:89',
    'data.len': '6'
  },
  {
            'data.data': '04:61:52:89:8b:89:89:89:c7:99',
    'data.len': '10'
  }
]"
    ,tRight = @"[
  {
    'data.data': '02:61:d4:89:0d:f7',
    'data.len': '6'
  },
  {
    'data.data': '02:61:d4:89:0d:f7',
    'data.len': '6'
  },
  {
    'data.data': '02:95:d4:89:89:af',
    'data.len': '6'
  },
  {
    'data.data': '02:a5:d4:89:89:bf',
    'data.len': '6'
  },
  {
    'data.data': '02:73:d4:89:89:8d',
    'data.len': '6'
  },
  {
    'data.data': '02:7d:d4:89:89:97',
    'data.len': '6'
  },
  {
    'data.data': '02:61:d4:89:0d:f7',
    'data.len': '6'
  },
  {
    'data.data': '02:73:d4:89:8d:89',
    'data.len': '6'
  },
  {
    'data.data': '02:0f:d4:89:89:29',
    'data.len': '6'
  },
  {
    'data.data': '02:1f:d4:89:89:39',
    'data.len': '6'
  },
  {
    'data.data': '01:f3:d4:0d:89:89',
    'data.len': '6'
  },
  {
    'data.data': '02:61:d4:89:0d:f7',
    'data.len': '6'
  },
  {
    'data.data': '02:61:d4:89:0d:f7',
    'data.len': '6'
  },
  {
    'data.data': '02:95:d4:89:89:af',
    'data.len': '6'
  },
  {
    'data.data': '02:a5:d4:89:89:bf',
    'data.len': '6'
  },
  {
    'data.data': '02:73:d4:89:89:8d',
    'data.len': '6'
  },
  {
    'data.data': '02:7d:d4:89:89:97',
    'data.len': '6'
  },
  {
    'data.data': '02:8f:d4:89:89:a9',
    'data.len': '6'
  },
  {
    'data.data': '03:b0:42:8b:89:89:0b:dd:e9',
    'data.len': '9'
  },
  {
    'data.data': '01:eb:d0:09:89:89',
    'data.len': '6'
  },
  {
    'data.data': '02:6d:d0:8b:89:89',
    'data.len': '6'
  },
  {
    'data.data': '02:0b:d0:29:89:89',
    'data.len': '6'
  },
  {
    'data.data': '02:8d:d0:ab:89:89',
    'data.len': '6'
  },
  {
    'data.data': '03:fd:52:89:8b:77:77:77:39:f9',
    'data.len': '10'
  }
]"
    , Up = @"[{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:95:d4:89:89:af', 'data.len': '6'},
{'data.data': '02:a5:d4:89:89:bf', 'data.len': '6'},
{'data.data': '02:73:d4:89:89:8d', 'data.len': '6'},
{'data.data': '02:7d:d4:89:89:97', 'data.len': '6'},
{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:73:d4:89:8d:89', 'data.len': '6'},
{'data.data': '02:0f:d4:89:89:29', 'data.len': '6'},
{'data.data': '02:1f:d4:89:89:39', 'data.len': '6'},
{'data.data': '01:f3:d4:0d:89:89', 'data.len': '6'},
{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:95:d4:89:89:af', 'data.len': '6'},
{'data.data': '02:a5:d4:89:89:bf', 'data.len': '6'},
{'data.data': '02:73:d4:89:89:8d', 'data.len': '6'},
{'data.data': '02:7d:d4:89:89:97', 'data.len': '6'},
{'data.data': '02:9f:d4:89:89:b9', 'data.len': '6'},
{'data.data': '03:b0:42:8b:89:89:0b:dd:e9', 'data.len': '9'},
{'data.data': '01:eb:d0:09:89:89', 'data.len': '6'},
{'data.data': '02:6d:d0:8b:89:89', 'data.len': '6'},
{'data.data': '02:0b:d0:29:89:89', 'data.len': '6'},
{'data.data': '02:8d:d0:ab:89:89', 'data.len': '6'},
{'data.data': '03:7d:52:09:8b:77:77:77:39:f9', 'data.len': '10'}]"
    ,Down = @"[{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:95:d4:89:89:af', 'data.len': '6'},
{'data.data': '02:a5:d4:89:89:bf', 'data.len': '6'},
{'data.data': '02:73:d4:89:89:8d', 'data.len': '6'},
{'data.data': '02:7d:d4:89:89:97', 'data.len': '6'},
{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:73:d4:89:8d:89', 'data.len': '6'},
{'data.data': '02:0f:d4:89:89:29', 'data.len': '6'},
{'data.data': '02:1f:d4:89:89:39', 'data.len': '6'},
{'data.data': '01:f3:d4:0d:89:89', 'data.len': '6'},
{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:95:d4:89:89:af', 'data.len': '6'},
{'data.data': '02:a5:d4:89:89:bf', 'data.len': '6'},
{'data.data': '02:73:d4:89:89:8d', 'data.len': '6'},
{'data.data': '02:7d:d4:89:89:97', 'data.len': '6'},
{'data.data': '02:9f:d4:89:89:b9', 'data.len': '6'},
{'data.data': '03:b0:42:8b:89:89:0b:dd:e9', 'data.len': '9'},
{'data.data': '01:eb:d0:09:89:89', 'data.len': '6'},
{'data.data': '02:6d:d0:8b:89:89', 'data.len': '6'},
{'data.data': '02:0b:d0:29:89:89', 'data.len': '6'},
{'data.data': '02:8d:d0:ab:89:89', 'data.len': '6'},
{'data.data': '03:e1:52:09:8b:89:89:89:c7:99', 'data.len': '10'}]"
    ,Home = @"[
  {'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:73:d4:89:8d:89', 'data.len': '6'},
{'data.data': '02:0f:d4:89:89:29', 'data.len': '6'},
{'data.data': '02:1f:d4:89:89:39', 'data.len': '6'},
{'data.data': '01:f3:d4:0d:89:89', 'data.len': '6'},
{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:61:d4:89:0d:f7', 'data.len': '6'},
{'data.data': '02:95:d4:89:89:af', 'data.len': '6'},
{'data.data': '02:a5:d4:89:89:bf', 'data.len': '6'},
{'data.data': '02:73:d4:89:89:8d', 'data.len': '6'},
{'data.data': '02:7d:d4:89:89:97', 'data.len': '6'},
{'data.data': '01:75:d2:a3', 'data.len': '4'}
]"
    ,Con_Left = @"[
{'data.data': '03:b0:42:8b:89:89:0b:dd:e9', 'data.len': '9'},
{'data.data': '02:6d:d4:89:8b:85', 'data.len': '6'},
{'data.data': '01:7b:d2:a9', 'data.len': '4'},
{'data.data': '01:8b:d2:b9', 'data.len': '4'}]"
    , Con_Right = @"[
{'data.data': '03:b0:42:8b:89:89:0b:dd:e9', 'data.len': '9'},
{'data.data': '02:6d:d4:89:8b:85', 'data.len': '6'},
{'data.data': '00:fb:d2:29', 'data.len': '4'},
{'data.data': '01:0b:d2:39', 'data.len': '4'}]"
    , Con_Up = @"[
{'data.data': '03:b0:42:8b:89:89:0b:dd:e9', 'data.len': '9'},
{'data.data': '02:6d:d4:89:8b:85', 'data.len': '6'},
{'data.data': '01:7d:d2:ab', 'data.len': '4'},
{'data.data': '01:8d:d2:bb', 'data.len': '4'},
]"
    , Con_Down = @"[
{'data.data': '03:b0:42:8b:89:89:0b:dd:e9', 'data.len': '9'},
{'data.data': '02:6d:d4:89:8b:85', 'data.len': '6'},
{'data.data': '00:fd:d2:2b', 'data.len': '4'},
{'data.data': '01:0d:d2:3b', 'data.len': '4'},
{'data.data': '01:0d:d2:3b', 'data.len': '4'}]"
    , Emergency_Stop = @"[
{'data.data': '01:8b:d2:b9', 'data.len': '4'},
{'data.data': '01:0b:d2:39', 'data.len': '4'},
{'data.data': '01:8d:d2:bb', 'data.len': '4'},
{'data.data': '01:0d:d2:3b', 'data.len': '4'}]";

}
