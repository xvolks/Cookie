package com.ankamagames.dofus.network.messages.game.alliance
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
   public class AllianceModificationStartedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6444;
       
      
      private var _isInitialized:Boolean = false;
      
      public var canChangeName:Boolean = false;
      
      public var canChangeTag:Boolean = false;
      
      public var canChangeEmblem:Boolean = false;
      
      public function AllianceModificationStartedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6444;
      }
      
      public function initAllianceModificationStartedMessage(param1:Boolean = false, param2:Boolean = false, param3:Boolean = false) : AllianceModificationStartedMessage
      {
         this.canChangeName = param1;
         this.canChangeTag = param2;
         this.canChangeEmblem = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.canChangeName = false;
         this.canChangeTag = false;
         this.canChangeEmblem = false;
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
         this.serializeAs_AllianceModificationStartedMessage(param1);
      }
      
      public function serializeAs_AllianceModificationStartedMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.canChangeName);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.canChangeTag);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,2,this.canChangeEmblem);
         param1.writeByte(_loc2_);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceModificationStartedMessage(param1);
      }
      
      public function deserializeAs_AllianceModificationStartedMessage(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceModificationStartedMessage(param1);
      }
      
      public function deserializeAsyncAs_AllianceModificationStartedMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.canChangeName = BooleanByteWrapper.getFlag(_loc2_,0);
         this.canChangeTag = BooleanByteWrapper.getFlag(_loc2_,1);
         this.canChangeEmblem = BooleanByteWrapper.getFlag(_loc2_,2);
      }
   }
}
