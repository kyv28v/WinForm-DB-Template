-- 商品マスタ
CREATE TABLE "M_Item" (
  "ItemID" integer			-- 商品ID
, "ItemName" text			-- 商品名
, "ItemPrice" integer			-- 商品価格
, "ReleaseDate" timestamptz			-- 発売日
, primary key ("ItemID")
);
