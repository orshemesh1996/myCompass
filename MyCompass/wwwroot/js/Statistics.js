function getPieChart() {
    var pie = new d3pie("pieChart", {
        "header": {
            "title": {
                "text": "Trip Categories",
                "fontSize": 24,
                "font": "open sans"
            },
            "subtitle": {
                "text": "A full pie chart to show the amount of trip categories around our website",
                "color": "#999999",
                "fontSize": 12,
                "font": "open sans"
            },
            "titleSubtitlePadding": 9
        },
        "footer": {
            "color": "#999999",
            "fontSize": 10,
            "font": "open sans",
            "location": "bottom-left"
        },
        "size": {
            "canvasWidth": 590,
            "pieOuterRadius": "90%"
        },
        "data": {
            "sortOrder": "value-desc",
            "content": [
                {
                    "label": "Java",
                    "value": 157618,
                    "color": "#4daa4b"
                },
                {
                    "label": "PHP",
                    "value": 114384,
                    "color": "#90c469"
                },
                {
                    "label": "Python",
                    "value": 95002,
                    "color": "#daca61"
                },
                {
                    "label": "C+",
                    "value": 78327,
                    "color": "#e4a14b"
                },
                {
                    "label": "C",
                    "value": 67706,
                    "color": "#e98125"
                },
                {
                    "label": "Objective-C",
                    "value": 36344,
                    "color": "#cb2121"
                },
                {
                    "label": "Shell",
                    "value": 28561,
                    "color": "#830909"
                },
                {
                    "label": "Cobol",
                    "value": 24131,
                    "color": "#923e99"
                },
                {
                    "label": "C#",
                    "value": 100,
                    "color": "#ae83d5"
                },
                {
                    "label": "Coldfusion",
                    "value": 68,
                    "color": "#bf273e"
                },
                {
                    "label": "Fortran",
                    "value": 218812,
                    "color": "#ce2aeb"
                },
                {
                    "label": "Coffeescript",
                    "value": 157618,
                    "color": "#bca44a"
                },
                {
                    "label": "Node",
                    "value": 114384,
                    "color": "#618d1b"
                },
                {
                    "label": "Basic",
                    "value": 95002,
                    "color": "#1ee67b"
                },
                {
                    "label": "Cola",
                    "value": 36344,
                    "color": "#b0ec44"
                },
                {
                    "label": "Perl",
                    "value": 32170,
                    "color": "#a4a0c9"
                },
            ]
        },
        "labels": {
            "outer": {
                "pieDistance": 32
            },
            "inner": {
                "hideWhenLessThanPercentage": 3
            },
            "mainLabel": {
                "fontSize": 11
            },
            "percentage": {
                "color": "#ffffff",
                "decimalPlaces": 0
            },
            "value": {
                "color": "#adadad",
                "fontSize": 11
            },
            "lines": {
                "enabled": true
            },
            "truncation": {
                "enabled": true
            }
        },
        "effects": {
            "pullOutSegmentOnClick": {
                "effect": "linear",
                "speed": 400,
                "size": 8
            }
        },
        "misc": {
            "gradient": {
                "enabled": true,
                "percentage": 100
            }
        }
    });
}
