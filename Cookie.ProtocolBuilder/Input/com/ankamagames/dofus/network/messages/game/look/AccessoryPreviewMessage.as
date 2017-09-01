package com.ankamagames.dofus.network.messages.game.look
{
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AccessoryPreviewMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6517;
       
      
      private var _isInitialized:Boolean = false;
      
      public var look:EntityLook;
      
      private var _looktree:FuncTree;
      
      public function AccessoryPreviewMessage()
      {
         this.look = new EntityLook();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6517;
      }
      
      public function initAccessoryPreviewMessage(param1:EntityLook = null) : AccessoryPreviewMessage
      {
         this.look = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.look = new EntityLook();
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
         this.serializeAs_AccessoryPreviewMessage(param1);
      }
      
      public function serializeAs_AccessoryPreviewMessage(param1:ICustomDataOutput) : void
      {
         this.look.serializeAs_EntityLook(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AccessoryPreviewMessage(param1);
      }
      
      public function deserializeAs_AccessoryPreviewMessage(param1:ICustomDataInput) : void
      {
         this.look = new EntityLook();
         this.look.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AccessoryPreviewMessage(param1);
      }
      
      public function deserializeAsyncAs_AccessoryPreviewMessage(param1:FuncTree) : void
      {
         this._looktree = param1.addChild(this._looktreeFunc);
      }
      
      private function _looktreeFunc(param1:ICustomDataInput) : void
      {
         this.look = new EntityLook();
         this.look.deserializeAsync(this._looktree);
      }
   }
}
