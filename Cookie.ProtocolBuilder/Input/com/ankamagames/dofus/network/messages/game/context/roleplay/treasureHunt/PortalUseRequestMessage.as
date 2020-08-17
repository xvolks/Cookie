package com.ankamagames.dofus.network.messages.game.context.roleplay.treasureHunt
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PortalUseRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6492;
       
      
      private var _isInitialized:Boolean = false;
      
      public var portalId:uint = 0;
      
      public function PortalUseRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6492;
      }
      
      public function initPortalUseRequestMessage(param1:uint = 0) : PortalUseRequestMessage
      {
         this.portalId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.portalId = 0;
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
         this.serializeAs_PortalUseRequestMessage(param1);
      }
      
      public function serializeAs_PortalUseRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.portalId < 0)
         {
            throw new Error("Forbidden value (" + this.portalId + ") on element portalId.");
         }
         param1.writeVarInt(this.portalId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PortalUseRequestMessage(param1);
      }
      
      public function deserializeAs_PortalUseRequestMessage(param1:ICustomDataInput) : void
      {
         this._portalIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PortalUseRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_PortalUseRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._portalIdFunc);
      }
      
      private function _portalIdFunc(param1:ICustomDataInput) : void
      {
         this.portalId = param1.readVarUhInt();
         if(this.portalId < 0)
         {
            throw new Error("Forbidden value (" + this.portalId + ") on element of PortalUseRequestMessage.portalId.");
         }
      }
   }
}
