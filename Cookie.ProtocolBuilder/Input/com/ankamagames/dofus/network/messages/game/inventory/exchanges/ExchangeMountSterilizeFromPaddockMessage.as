package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeMountSterilizeFromPaddockMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6056;
       
      
      private var _isInitialized:Boolean = false;
      
      public var name:String = "";
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var sterilizator:String = "";
      
      public function ExchangeMountSterilizeFromPaddockMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6056;
      }
      
      public function initExchangeMountSterilizeFromPaddockMessage(param1:String = "", param2:int = 0, param3:int = 0, param4:String = "") : ExchangeMountSterilizeFromPaddockMessage
      {
         this.name = param1;
         this.worldX = param2;
         this.worldY = param3;
         this.sterilizator = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.name = "";
         this.worldX = 0;
         this.worldY = 0;
         this.sterilizator = "";
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ExchangeMountSterilizeFromPaddockMessage(param1);
      }
      
      public function serializeAs_ExchangeMountSterilizeFromPaddockMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.name);
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element worldX.");
         }
         param1.writeShort(this.worldX);
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element worldY.");
         }
         param1.writeShort(this.worldY);
         param1.writeUTF(this.sterilizator);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeMountSterilizeFromPaddockMessage(param1);
      }
      
      public function deserializeAs_ExchangeMountSterilizeFromPaddockMessage(param1:ICustomDataInput) : void
      {
         this._nameFunc(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._sterilizatorFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeMountSterilizeFromPaddockMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeMountSterilizeFromPaddockMessage(param1:FuncTree) : void
      {
         param1.addChild(this._nameFunc);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._sterilizatorFunc);
      }
      
      private function _nameFunc(param1:ICustomDataInput) : void
      {
         this.name = param1.readUTF();
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of ExchangeMountSterilizeFromPaddockMessage.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of ExchangeMountSterilizeFromPaddockMessage.worldY.");
         }
      }
      
      private function _sterilizatorFunc(param1:ICustomDataInput) : void
      {
         this.sterilizator = param1.readUTF();
      }
   }
}
