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
   public class TeleportOnSameMapMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6048;
       
      
      private var _isInitialized:Boolean = false;
      
      public var targetId:Number = 0;
      
      public var cellId:uint = 0;
      
      public function TeleportOnSameMapMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6048;
      }
      
      public function initTeleportOnSameMapMessage(param1:Number = 0, param2:uint = 0) : TeleportOnSameMapMessage
      {
         this.targetId = param1;
         this.cellId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.targetId = 0;
         this.cellId = 0;
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
         this.serializeAs_TeleportOnSameMapMessage(param1);
      }
      
      public function serializeAs_TeleportOnSameMapMessage(param1:ICustomDataOutput) : void
      {
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeDouble(this.targetId);
         if(this.cellId < 0 || this.cellId > 559)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element cellId.");
         }
         param1.writeVarShort(this.cellId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TeleportOnSameMapMessage(param1);
      }
      
      public function deserializeAs_TeleportOnSameMapMessage(param1:ICustomDataInput) : void
      {
         this._targetIdFunc(param1);
         this._cellIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TeleportOnSameMapMessage(param1);
      }
      
      public function deserializeAsyncAs_TeleportOnSameMapMessage(param1:FuncTree) : void
      {
         param1.addChild(this._targetIdFunc);
         param1.addChild(this._cellIdFunc);
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readDouble();
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of TeleportOnSameMapMessage.targetId.");
         }
      }
      
      private function _cellIdFunc(param1:ICustomDataInput) : void
      {
         this.cellId = param1.readVarUhShort();
         if(this.cellId < 0 || this.cellId > 559)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element of TeleportOnSameMapMessage.cellId.");
         }
      }
   }
}
