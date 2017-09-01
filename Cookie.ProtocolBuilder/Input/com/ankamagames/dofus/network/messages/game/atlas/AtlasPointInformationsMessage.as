package com.ankamagames.dofus.network.messages.game.atlas
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.AtlasPointsInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AtlasPointInformationsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5956;
       
      
      private var _isInitialized:Boolean = false;
      
      public var type:AtlasPointsInformations;
      
      private var _typetree:FuncTree;
      
      public function AtlasPointInformationsMessage()
      {
         this.type = new AtlasPointsInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5956;
      }
      
      public function initAtlasPointInformationsMessage(param1:AtlasPointsInformations = null) : AtlasPointInformationsMessage
      {
         this.type = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.type = new AtlasPointsInformations();
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
         this.serializeAs_AtlasPointInformationsMessage(param1);
      }
      
      public function serializeAs_AtlasPointInformationsMessage(param1:ICustomDataOutput) : void
      {
         this.type.serializeAs_AtlasPointsInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AtlasPointInformationsMessage(param1);
      }
      
      public function deserializeAs_AtlasPointInformationsMessage(param1:ICustomDataInput) : void
      {
         this.type = new AtlasPointsInformations();
         this.type.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AtlasPointInformationsMessage(param1);
      }
      
      public function deserializeAsyncAs_AtlasPointInformationsMessage(param1:FuncTree) : void
      {
         this._typetree = param1.addChild(this._typetreeFunc);
      }
      
      private function _typetreeFunc(param1:ICustomDataInput) : void
      {
         this.type = new AtlasPointsInformations();
         this.type.deserializeAsync(this._typetree);
      }
   }
}
