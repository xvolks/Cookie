package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.dofus.network.messages.game.actions.AbstractGameActionMessage;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameActionFightActivateGlyphTrapMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6545;
       
      
      private var _isInitialized:Boolean = false;
      
      public var markId:int = 0;
      
      public var active:Boolean = false;
      
      public function GameActionFightActivateGlyphTrapMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6545;
      }
      
      public function initGameActionFightActivateGlyphTrapMessage(param1:uint = 0, param2:Number = 0, param3:int = 0, param4:Boolean = false) : GameActionFightActivateGlyphTrapMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.markId = param3;
         this.active = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.markId = 0;
         this.active = false;
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
         this.serializeAs_GameActionFightActivateGlyphTrapMessage(param1);
      }
      
      public function serializeAs_GameActionFightActivateGlyphTrapMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         param1.writeShort(this.markId);
         param1.writeBoolean(this.active);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightActivateGlyphTrapMessage(param1);
      }
      
      public function deserializeAs_GameActionFightActivateGlyphTrapMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._markIdFunc(param1);
         this._activeFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightActivateGlyphTrapMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightActivateGlyphTrapMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._markIdFunc);
         param1.addChild(this._activeFunc);
      }
      
      private function _markIdFunc(param1:ICustomDataInput) : void
      {
         this.markId = param1.readShort();
      }
      
      private function _activeFunc(param1:ICustomDataInput) : void
      {
         this.active = param1.readBoolean();
      }
   }
}
