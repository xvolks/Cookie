package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.messages.game.actions.AbstractGameActionMessage;
   import com.ankamagames.dofus.network.types.game.actions.fight.AbstractFightDispellableEffect;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameActionFightDispellableEffectMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6070;
       
      
      private var _isInitialized:Boolean = false;
      
      public var effect:AbstractFightDispellableEffect;
      
      private var _effecttree:FuncTree;
      
      public function GameActionFightDispellableEffectMessage()
      {
         this.effect = new AbstractFightDispellableEffect();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6070;
      }
      
      public function initGameActionFightDispellableEffectMessage(param1:uint = 0, param2:Number = 0, param3:AbstractFightDispellableEffect = null) : GameActionFightDispellableEffectMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.effect = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.effect = new AbstractFightDispellableEffect();
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
         this.serializeAs_GameActionFightDispellableEffectMessage(param1);
      }
      
      public function serializeAs_GameActionFightDispellableEffectMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         param1.writeShort(this.effect.getTypeId());
         this.effect.serialize(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightDispellableEffectMessage(param1);
      }
      
      public function deserializeAs_GameActionFightDispellableEffectMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.effect = ProtocolTypeManager.getInstance(AbstractFightDispellableEffect,_loc2_);
         this.effect.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightDispellableEffectMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightDispellableEffectMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._effecttree = param1.addChild(this._effecttreeFunc);
      }
      
      private function _effecttreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.effect = ProtocolTypeManager.getInstance(AbstractFightDispellableEffect,_loc2_);
         this.effect.deserializeAsync(this._effecttree);
      }
   }
}
