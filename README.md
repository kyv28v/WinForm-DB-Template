# WinForm-DB-Template


# 動作環境


# 使用方法

データベース（PostgreSQL）の構築は割愛します。  
適当に構築してください。  

## １．ExcelのDB仕様書からCreateTable文を自動生成  

`DB`フォルダにある`10_ファイル情報出力マクロ.xlsm`を開き、`実行`シートの`実行`ボタンをクリックします。  
必要に応じて、データベース接続設定を修正してください。  

<img width="759" height="236" alt="image" src="https://github.com/user-attachments/assets/3d11a451-929c-4c7b-a315-982c63e60833" />


ファイル選択ダイアログが表示されますので、同フォルダにある`ファイル仕様書サンプル.xlsx`を選択します。  

<img width="421" height="266" alt="image" src="https://github.com/user-attachments/assets/b9ae9f9e-2999-495f-9ffd-e23750a320df" />

`ファイル仕様書サンプル.xlsx`の定義に従って、`CreateTable`フォルダにCreateTable文が記載されたsqlファイルが生成されます。

<img width="416" height="267" alt="image" src="https://github.com/user-attachments/assets/0efc62fa-1755-4c88-a099-f631b835ec01" />

また、`DB`フォルダ直下に、モデル生成のためのコマンドファイル`20_CreateModels.bat`が生成されます。

## ２．CreateTable文を実行し、データベースに反映  

１で生成された`CreateTable`フォルダに、sqlファイルをまとめて実行するためのバッチ`_CreatTable.bat`も生成されていますので、これを実行します。

## ３．データベース情報からモデルクラスを自動生成  


