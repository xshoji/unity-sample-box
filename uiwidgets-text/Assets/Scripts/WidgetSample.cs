using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using FontStyle = Unity.UIWidgets.ui.FontStyle;

namespace UIWidgetsSample
{
    public class WidgetSample : UIWidgetsPanel
    {

        protected override void OnEnable()
        {
            // if you want to use your own font or font icons.
            // FontManager.instance.addFont(Resources.Load<Font>(path: "path to your font"), "font family name");

            // load custom font with weight & style. The font weight & style corresponds to fontWeight, fontStyle of
            // a TextStyle object
            // FontManager.instance.addFont(Resources.Load<Font>(path: "path to your font"), "Roboto", FontWeight.w500,
            //    FontStyle.italic);

            // add material icons, familyName must be "Material Icons"
            // FontManager.instance.addFont(Resources.Load<Font>(path: "path to material icons"), "Material Icons");
            FontManager.instance.addFont(Resources.Load<Font>(path: "MaterialIcons-Regular"), "Material Icons");
            base.OnEnable();
        }

        protected override Widget createWidget()
        {
            return new ExampleApp();
        }

        // > 【Unity】Unity上でFlutter！？　UIWidgetsアセットの初歩的な使い方 - Qiita  
        // > https://qiita.com/NWaka_1415/items/d74f7a6d4198e70e4b0d
        // > FlutterでbottomNavigationBarを実装する - makicamelの日記  
        // > https://makicamel.hatenablog.com/entry/2019/03/25/230423
        // > Icons class - material library - Dart API  
        // > https://api.flutter.dev/flutter/material/Icons-class.html
        // > BottomNavigationBar class - material library - Dart API  
        // > https://api.flutter.dev/flutter/material/BottomNavigationBar-class.html
        class ExampleApp : StatelessWidget
        {
            public override Widget build(BuildContext context)
            {
                return new MaterialApp(
                    title: "MaterialApp",
                    home: new Scaffold(
                        appBar: new AppBar(
                            backgroundColor: new Unity.UIWidgets.ui.Color(0xFF808080),
                            title: new Text("Todo App")
                            ),
                        body: new Center(
                            child: new Text("Hellow World")
                            ),
                        bottomNavigationBar: new BottomNavigationBar(
                            items: new List<BottomNavigationBarItem> {
                                new BottomNavigationBarItem(
                                    new Icon(new IconData(58834, "Material Icons"), color: new Unity.UIWidgets.ui.Color(0xFF000000))
                                    ),
                                new BottomNavigationBarItem(
                                    new Icon(Icons.search, color: new Unity.UIWidgets.ui.Color(0xFF000000))
                                    )
                            }
                            )
                        )
                    
                );
            }
        }
    }
}