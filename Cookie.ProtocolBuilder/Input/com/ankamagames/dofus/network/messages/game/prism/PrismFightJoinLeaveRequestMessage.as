package com.ankamagames.dofus.network.messages.game.prism
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PrismFightJoinLeaveRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5843;
       
      
      private var _isInitialized:Boolean = false;
      
      public var subAreaId:uint = 0;
      
      public var join:Boolean = false;
      
      public function PrismFightJoinLeaveRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5843;
      }
      
      public function initPrismFightJoinLeaveRequestMessage(param1:uint = 0, param2:Boolean = false) : PrismFightJoinLeaveRequestMessage
      {
         this.subAreaId = param1;
         this.join = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.subAreaId = 0;
         this.join = false;
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
         this.serializeAs_PrismFightJoinLeaveRequestMessage(param1);
      }
      
      public function serializeAs_PrismFightJoinLeaveRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
         param1.writeBoolean(this.join);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PrismFightJoinLeaveRequestMessage(param1);
      }
      
      public function deserializeAs_PrismFightJoinLeaveRequestMessage(param1:ICustomDataInput) : void
      {
         this._subAreaIdFunc(param1);
         this._joinFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PrismFightJoinLeaveRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_PrismFightJoinLeaveRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._subAreaIdFunc);
         param1.addChild(this._joinFunc);
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of PrismFightJoinLeaveRequestMessage.subAreaId.");
         }
      }
      
      private function _joinFunc(param1:ICustomDataInput) : void
      {
         this.join = param1.readBoolean();
      }
   }
}
