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
   public class RecycleResultMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6601;
       
      
      private var _isInitialized:Boolean = false;
      
      public var nuggetsForPrism:uint = 0;
      
      public var nuggetsForPlayer:uint = 0;
      
      public function RecycleResultMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6601;
      }
      
      public function initRecycleResultMessage(param1:uint = 0, param2:uint = 0) : RecycleResultMessage
      {
         this.nuggetsForPrism = param1;
         this.nuggetsForPlayer = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.nuggetsForPrism = 0;
         this.nuggetsForPlayer = 0;
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
         this.serializeAs_RecycleResultMessage(param1);
      }
      
      public function serializeAs_RecycleResultMessage(param1:ICustomDataOutput) : void
      {
         if(this.nuggetsForPrism < 0)
         {
            throw new Error("Forbidden value (" + this.nuggetsForPrism + ") on element nuggetsForPrism.");
         }
         param1.writeVarInt(this.nuggetsForPrism);
         if(this.nuggetsForPlayer < 0)
         {
            throw new Error("Forbidden value (" + this.nuggetsForPlayer + ") on element nuggetsForPlayer.");
         }
         param1.writeVarInt(this.nuggetsForPlayer);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_RecycleResultMessage(param1);
      }
      
      public function deserializeAs_RecycleResultMessage(param1:ICustomDataInput) : void
      {
         this._nuggetsForPrismFunc(param1);
         this._nuggetsForPlayerFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_RecycleResultMessage(param1);
      }
      
      public function deserializeAsyncAs_RecycleResultMessage(param1:FuncTree) : void
      {
         param1.addChild(this._nuggetsForPrismFunc);
         param1.addChild(this._nuggetsForPlayerFunc);
      }
      
      private function _nuggetsForPrismFunc(param1:ICustomDataInput) : void
      {
         this.nuggetsForPrism = param1.readVarUhInt();
         if(this.nuggetsForPrism < 0)
         {
            throw new Error("Forbidden value (" + this.nuggetsForPrism + ") on element of RecycleResultMessage.nuggetsForPrism.");
         }
      }
      
      private function _nuggetsForPlayerFunc(param1:ICustomDataInput) : void
      {
         this.nuggetsForPlayer = param1.readVarUhInt();
         if(this.nuggetsForPlayer < 0)
         {
            throw new Error("Forbidden value (" + this.nuggetsForPlayer + ") on element of RecycleResultMessage.nuggetsForPlayer.");
         }
      }
   }
}
