# WinForm-DB-Template
C#でWindowsフォームアプリを作るときの、DB接続部分のサンプルを実装したテンプレートです。  
ExcelでDB仕様書を作成するケースを想定し、以下の流れでデータベースとコードを自動生成するようにしています。  

１．ExcelのDB仕様書からCreateTable文を自動生成  
２．CreateTable文を実行し、データベースに反映  
３．データベース情報からモデルクラスを自動生成  

１については、VBAマクロを使用しています。  
３については、`EF Core ツール`の機能を使います。

# 動作環境
VisualStudio2022  
.Net8.0  
PostgreSQL 16.2  

# 使用方法

データベース（PostgreSQL）の構築は割愛します。  
適当に構築してください。  

## １．ExcelのDB仕様書からCreateTable文を自動生成  

`DB`フォルダにある`10_ファイル情報出力マクロ.xlsm`を開き、`実行`シートの`実行`ボタンをクリックします。  
必要に応じて、データベース接続設定を修正してください。  

ファイル選択ダイアログが表示されますので、同フォルダにある`ファイル仕様書サンプル.xlsx`を選択します。  

`ファイル仕様書サンプル.xlsx`の定義に従って、`CreateTable`フォルダにCreateTable文が記載されたsqlファイルが生成されます。

また、`DB`フォルダ直下に、モデル生成のためのコマンドファイル`20_CreateModels.bat`が生成されます。

## ２．CreateTable文を実行し、データベースに反映  

１で生成された`CreateTable`フォルダに、sqlファイルをまとめて実行するためのバッチ`_CreatTable.bat`も生成されていますので、これを実行します。  
CreateTable文が実行され、テーブルが生成されます。  

## ３．データベース情報からモデルクラスを自動生成  
１で生成された`20_CreateModels.bat`を実行すると、データベース情報からモデルクラスが自動生成され、`Models`フォルダに保存されます。
※ `EF Core ツール`のインストールが必要です。
```
>dotnet tool install --global dotnet-ef
次のコマンドを使用してツールを呼び出せます。dotnet-ef
ツール 'dotnet-ef' (バージョン '9.0.7') が正常にインストールされました。
```

# テスト実行
アプリを実行し、`テストデータ取得`ボタンをクリックすると、DBからデータを取得して一覧表示します。  
以下、テストデータのサンプルです。

```
INSERT INTO "M_Store" VALUES(1, '本店',   '東京都1-1-1');
INSERT INTO "M_Store" VALUES(2, '横浜店', '横浜市2-2-2');

INSERT INTO "M_Item" VALUES(1, '商品A', 100, '2025/07/21 9:00:00');
INSERT INTO "M_Item" VALUES(2, '商品B', 200, '2025/07/21 9:00:00');

INSERT INTO "I_Sales" VALUES(1, '2025/07/21 15:30:15.111', 1);
INSERT INTO "I_Sales" VALUES(2, '2025/07/21 15:40:25.222', 2);

INSERT INTO "I_SalesDetail" VALUES(1, 1, 1, 1);
INSERT INTO "I_SalesDetail" VALUES(1, 2, 2, 5);
INSERT INTO "I_SalesDetail" VALUES(2, 2, 2, 2);
```

テストデータ取得結果

<img width="1076" height="474" alt="image" src="https://github.com/user-attachments/assets/c7907ce3-b502-4d4b-8a80-e69c81254616" />

# 注意点
* 実際に使用するときは、`10_ファイル情報出力マクロ.xlsm`のマクロを実際のDB仕様書にあうように修正する必要があります。  
（項目名や型が記載されている列や、開始行など。）  
また、現状は`ファイル仕様書サンプル.xlsx`を使用して自動生成された結果をコミットしていますので、不要なファイルは削除してください。  




