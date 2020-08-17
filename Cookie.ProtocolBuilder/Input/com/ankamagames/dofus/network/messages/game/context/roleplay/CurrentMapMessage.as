package com.ankamagames.dofus.network.messages.game.context.roleplay
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CurrentMapMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 220;
       
      
      private var _isInitialized:Boolean = false;
      
      public var mapId:uint = 0;
      
      public var mapKey:String = "";
      
      public function CurrentMapMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 220;
      }
      
      public function initCurrentMapMessage(param1:uint = 0, param2:String = "") : CurrentMapMessage
      {
         this.mapId = param1;
         this.mapKey = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.mapId = 0;
         this.mapKey = "";
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
         this.serializeAs_CurrentMapMessage(param1);
      }
      
      public function serializeAs_CurrentMapMessage(param1:ICustomDataOutput) : void
      {
         if(this.mapId < 0)
         {
            throw new Error("Forbidden value (" + this.mapId + ") on element mapId.");
         }
         param1.writeInt(this.mapId);
         param1.writeUTF(this.mapKey);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CurrentMapMessage(param1);
      }
      
      public function deserializeAs_CurrentMapMessage(param1:ICustomDataInput) : void
      {
         this._mapIdFunc(param1);
         this._mapKeyFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CurrentMapMessage(param1);
      }
      
      public function deserializeAsyncAs_CurrentMapMessage(param1:FuncTree) : void
      {
         param1.addChild(this._mapIdFunc);
         param1.addChild(this._mapKeyFunc);
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
         if(this.mapId < 0)
         {
            throw new Error("Forbidden value (" + this.mapId + ") on element of CurrentMapMessage.mapId.");
         }
      }
      
      private function _mapKeyFunc(param1:ICustomDataInput) : void
      {
         this.mapKey = param1.readUTF();
      }
   }
}
