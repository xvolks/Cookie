package com.ankamagames.dofus.network.types.game.startup
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItemInformationWithQuantity;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class StartupActionAddObject implements INetworkType
   {
      
      public static const protocolId:uint = 52;
       
      
      public var uid:uint = 0;
      
      public var title:String = "";
      
      public var text:String = "";
      
      public var descUrl:String = "";
      
      public var pictureUrl:String = "";
      
      public var items:Vector.<ObjectItemInformationWithQuantity>;
      
      private var _itemstree:FuncTree;
      
      public function StartupActionAddObject()
      {
         this.items = new Vector.<ObjectItemInformationWithQuantity>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 52;
      }
      
      public function initStartupActionAddObject(param1:uint = 0, param2:String = "", param3:String = "", param4:String = "", param5:String = "", param6:Vector.<ObjectItemInformationWithQuantity> = null) : StartupActionAddObject
      {
         this.uid = param1;
         this.title = param2;
         this.text = param3;
         this.descUrl = param4;
         this.pictureUrl = param5;
         this.items = param6;
         return this;
      }
      
      public function reset() : void
      {
         this.uid = 0;
         this.title = "";
         this.text = "";
         this.descUrl = "";
         this.pictureUrl = "";
         this.items = new Vector.<ObjectItemInformationWithQuantity>();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_StartupActionAddObject(param1);
      }
      
      public function serializeAs_StartupActionAddObject(param1:ICustomDataOutput) : void
      {
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element uid.");
         }
         param1.writeInt(this.uid);
         param1.writeUTF(this.title);
         param1.writeUTF(this.text);
         param1.writeUTF(this.descUrl);
         param1.writeUTF(this.pictureUrl);
         param1.writeShort(this.items.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.items.length)
         {
            (this.items[_loc2_] as ObjectItemInformationWithQuantity).serializeAs_ObjectItemInformationWithQuantity(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_StartupActionAddObject(param1);
      }
      
      public function deserializeAs_StartupActionAddObject(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItemInformationWithQuantity = null;
         this._uidFunc(param1);
         this._titleFunc(param1);
         this._textFunc(param1);
         this._descUrlFunc(param1);
         this._pictureUrlFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItemInformationWithQuantity();
            _loc4_.deserialize(param1);
            this.items.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_StartupActionAddObject(param1);
      }
      
      public function deserializeAsyncAs_StartupActionAddObject(param1:FuncTree) : void
      {
         param1.addChild(this._uidFunc);
         param1.addChild(this._titleFunc);
         param1.addChild(this._textFunc);
         param1.addChild(this._descUrlFunc);
         param1.addChild(this._pictureUrlFunc);
         this._itemstree = param1.addChild(this._itemstreeFunc);
      }
      
      private function _uidFunc(param1:ICustomDataInput) : void
      {
         this.uid = param1.readInt();
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element of StartupActionAddObject.uid.");
         }
      }
      
      private function _titleFunc(param1:ICustomDataInput) : void
      {
         this.title = param1.readUTF();
      }
      
      private function _textFunc(param1:ICustomDataInput) : void
      {
         this.text = param1.readUTF();
      }
      
      private function _descUrlFunc(param1:ICustomDataInput) : void
      {
         this.descUrl = param1.readUTF();
      }
      
      private function _pictureUrlFunc(param1:ICustomDataInput) : void
      {
         this.pictureUrl = param1.readUTF();
      }
      
      private function _itemstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._itemstree.addChild(this._itemsFunc);
            _loc3_++;
         }
      }
      
      private function _itemsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItemInformationWithQuantity = new ObjectItemInformationWithQuantity();
         _loc2_.deserialize(param1);
         this.items.push(_loc2_);
      }
   }
}
