package com.ankamagames.dofus.network.messages.secure
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TrustStatusMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6267;
       
      
      private var _isInitialized:Boolean = false;
      
      public var trusted:Boolean = false;
      
      public var certified:Boolean = false;
      
      public function TrustStatusMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6267;
      }
      
      public function initTrustStatusMessage(param1:Boolean = false, param2:Boolean = false) : TrustStatusMessage
      {
         this.trusted = param1;
         this.certified = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.trusted = false;
         this.certified = false;
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
         this.serializeAs_TrustStatusMessage(param1);
      }
      
      public function serializeAs_TrustStatusMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.trusted);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.certified);
         param1.writeByte(_loc2_);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TrustStatusMessage(param1);
      }
      
      public function deserializeAs_TrustStatusMessage(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TrustStatusMessage(param1);
      }
      
      public function deserializeAsyncAs_TrustStatusMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.trusted = BooleanByteWrapper.getFlag(_loc2_,0);
         this.certified = BooleanByteWrapper.getFlag(_loc2_,1);
      }
   }
}
