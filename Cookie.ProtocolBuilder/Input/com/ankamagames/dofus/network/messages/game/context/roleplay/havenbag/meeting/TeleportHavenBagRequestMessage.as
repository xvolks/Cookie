package com.ankamagames.dofus.network.messages.game.context.roleplay.havenbag.meeting
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TeleportHavenBagRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6647;
       
      
      private var _isInitialized:Boolean = false;
      
      public var guestId:Number = 0;
      
      public function TeleportHavenBagRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6647;
      }
      
      public function initTeleportHavenBagRequestMessage(param1:Number = 0) : TeleportHavenBagRequestMessage
      {
         this.guestId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.guestId = 0;
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
         this.serializeAs_TeleportHavenBagRequestMessage(param1);
      }
      
      public function serializeAs_TeleportHavenBagRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.guestId < 0 || this.guestId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.guestId + ") on element guestId.");
         }
         param1.writeVarLong(this.guestId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TeleportHavenBagRequestMessage(param1);
      }
      
      public function deserializeAs_TeleportHavenBagRequestMessage(param1:ICustomDataInput) : void
      {
         this._guestIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TeleportHavenBagRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_TeleportHavenBagRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._guestIdFunc);
      }
      
      private function _guestIdFunc(param1:ICustomDataInput) : void
      {
         this.guestId = param1.readVarUhLong();
         if(this.guestId < 0 || this.guestId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.guestId + ") on element of TeleportHavenBagRequestMessage.guestId.");
         }
      }
   }
}
