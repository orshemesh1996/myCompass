Categories = []
function createCategoriesCounter(categories) {
    console.log(categories);
}

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
