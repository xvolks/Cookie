package com.ankamagames.dofus.network.messages.game.dare
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DareRewardConsumeValidationMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6675;
       
      
      private var _isInitialized:Boolean = false;
      
      public var dareId:Number = 0;
      
      public var type:uint = 0;
      
      public function DareRewardConsumeValidationMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6675;
      }
      
      public function initDareRewardConsumeValidationMessage(param1:Number = 0, param2:uint = 0) : DareRewardConsumeValidationMessage
      {
         this.dareId = param1;
         this.type = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.dareId = 0;
         this.type = 0;
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
         this.serializeAs_DareRewardConsumeValidationMessage(param1);
      }
      
      public function serializeAs_DareRewardConsumeValidationMessage(param1:ICustomDataOutput) : void
      {
         if(this.dareId < 0 || this.dareId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.dareId + ") on element dareId.");
         }
         param1.writeDouble(this.dareId);
         param1.writeByte(this.type);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareRewardConsumeValidationMessage(param1);
      }
      
      public function deserializeAs_DareRewardConsumeValidationMessage(param1:ICustomDataInput) : void
      {
         this._dareIdFunc(param1);
         this._typeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareRewardConsumeValidationMessage(param1);
      }
      
      public function deserializeAsyncAs_DareRewardConsumeValidationMessage(param1:FuncTree) : void
      {
         param1.addChild(this._dareIdFunc);
         param1.addChild(this._typeFunc);
      }
      
      private function _dareIdFunc(param1:ICustomDataInput) : void
      {
         this.dareId = param1.readDouble();
         if(this.dareId < 0 || this.dareId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.dareId + ") on element of DareRewardConsumeValidationMessage.dareId.");
         }
      }
      
      private function _typeFunc(param1:ICustomDataInput) : void
      {
         this.type = param1.readByte();
         if(this.type < 0)
         {
            throw new Error("Forbidden value (" + this.type + ") on element of DareRewardConsumeValidationMessage.type.");
         }
      }
   }
}
