package com.ankamagames.dofus.network.messages.connection
{
   import com.ankamagames.dofus.network.types.version.Version;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IdentificationFailedForBadVersionMessage extends IdentificationFailedMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 21;
       
      
      private var _isInitialized:Boolean = false;
      
      public var requiredVersion:Version;
      
      private var _requiredVersiontree:FuncTree;
      
      public function IdentificationFailedForBadVersionMessage()
      {
         this.requiredVersion = new Version();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 21;
      }
      
      public function initIdentificationFailedForBadVersionMessage(param1:uint = 99, param2:Version = null) : IdentificationFailedForBadVersionMessage
      {
         super.initIdentificationFailedMessage(param1);
         this.requiredVersion = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.requiredVersion = new Version();
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_IdentificationFailedForBadVersionMessage(param1);
      }
      
      public function serializeAs_IdentificationFailedForBadVersionMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_IdentificationFailedMessage(param1);
         this.requiredVersion.serializeAs_Version(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IdentificationFailedForBadVersionMessage(param1);
      }
      
      public function deserializeAs_IdentificationFailedForBadVersionMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.requiredVersion = new Version();
         this.requiredVersion.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IdentificationFailedForBadVersionMessage(param1);
      }
      
      public function deserializeAsyncAs_IdentificationFailedForBadVersionMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._requiredVersiontree = param1.addChild(this._requiredVersiontreeFunc);
      }
      
      private function _requiredVersiontreeFunc(param1:ICustomDataInput) : void
      {
         this.requiredVersion = new Version();
         this.requiredVersion.deserializeAsync(this._requiredVersiontree);
      }
   }
}
