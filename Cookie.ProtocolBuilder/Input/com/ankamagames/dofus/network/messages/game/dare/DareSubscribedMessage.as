package com.ankamagames.dofus.network.messages.game.dare
{
   import com.ankamagames.dofus.network.types.game.dare.DareVersatileInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DareSubscribedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6660;
       
      
      private var _isInitialized:Boolean = false;
      
      public var dareId:Number = 0;
      
      public var success:Boolean = false;
      
      public var subscribe:Boolean = false;
      
      public var dareVersatilesInfos:DareVersatileInformations;
      
      private var _dareVersatilesInfostree:FuncTree;
      
      public function DareSubscribedMessage()
      {
         this.dareVersatilesInfos = new DareVersatileInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6660;
      }
      
      public function initDareSubscribedMessage(param1:Number = 0, param2:Boolean = false, param3:Boolean = false, param4:DareVersatileInformations = null) : DareSubscribedMessage
      {
         this.dareId = param1;
         this.success = param2;
         this.subscribe = param3;
         this.dareVersatilesInfos = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.dareId = 0;
         this.success = false;
         this.subscribe = false;
         this.dareVersatilesInfos = new DareVersatileInformations();
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
         this.serializeAs_DareSubscribedMessage(param1);
      }
      
      public function serializeAs_DareSubscribedMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.success);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.subscribe);
         param1.writeByte(_loc2_);
         if(this.dareId < 0 || this.dareId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.dareId + ") on element dareId.");
         }
         param1.writeDouble(this.dareId);
         this.dareVersatilesInfos.serializeAs_DareVersatileInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareSubscribedMessage(param1);
      }
      
      public function deserializeAs_DareSubscribedMessage(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
         this._dareIdFunc(param1);
         this.dareVersatilesInfos = new DareVersatileInformations();
         this.dareVersatilesInfos.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareSubscribedMessage(param1);
      }
      
      public function deserializeAsyncAs_DareSubscribedMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._dareIdFunc);
         this._dareVersatilesInfostree = param1.addChild(this._dareVersatilesInfostreeFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.success = BooleanByteWrapper.getFlag(_loc2_,0);
         this.subscribe = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _dareIdFunc(param1:ICustomDataInput) : void
      {
         this.dareId = param1.readDouble();
         if(this.dareId < 0 || this.dareId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.dareId + ") on element of DareSubscribedMessage.dareId.");
         }
      }
      
      private function _dareVersatilesInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.dareVersatilesInfos = new DareVersatileInformations();
         this.dareVersatilesInfos.deserializeAsync(this._dareVersatilesInfostree);
      }
   }
}
