package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayGroupMonsterWaveInformations extends GameRolePlayGroupMonsterInformations implements INetworkType
   {
      
      public static const protocolId:uint = 464;
       
      
      public var nbWaves:uint = 0;
      
      public var alternatives:Vector.<GroupMonsterStaticInformations>;
      
      private var _alternativestree:FuncTree;
      
      public function GameRolePlayGroupMonsterWaveInformations()
      {
         this.alternatives = new Vector.<GroupMonsterStaticInformations>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 464;
      }
      
      public function initGameRolePlayGroupMonsterWaveInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:GroupMonsterStaticInformations = null, param5:Number = 0, param6:uint = 0, param7:int = 0, param8:int = 0, param9:Boolean = false, param10:Boolean = false, param11:Boolean = false, param12:uint = 0, param13:Vector.<GroupMonsterStaticInformations> = null) : GameRolePlayGroupMonsterWaveInformations
      {
         super.initGameRolePlayGroupMonsterInformations(param1,param2,param3,param4,param5,param6,param7,param8,param9,param10,param11);
         this.nbWaves = param12;
         this.alternatives = param13;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.nbWaves = 0;
         this.alternatives = new Vector.<GroupMonsterStaticInformations>();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayGroupMonsterWaveInformations(param1);
      }
      
      public function serializeAs_GameRolePlayGroupMonsterWaveInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayGroupMonsterInformations(param1);
         if(this.nbWaves < 0)
         {
            throw new Error("Forbidden value (" + this.nbWaves + ") on element nbWaves.");
         }
         param1.writeByte(this.nbWaves);
         param1.writeShort(this.alternatives.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.alternatives.length)
         {
            param1.writeShort((this.alternatives[_loc2_] as GroupMonsterStaticInformations).getTypeId());
            (this.alternatives[_loc2_] as GroupMonsterStaticInformations).serialize(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayGroupMonsterWaveInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayGroupMonsterWaveInformations(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:GroupMonsterStaticInformations = null;
         super.deserialize(param1);
         this._nbWavesFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(GroupMonsterStaticInformations,_loc4_);
            _loc5_.deserialize(param1);
            this.alternatives.push(_loc5_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayGroupMonsterWaveInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayGroupMonsterWaveInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._nbWavesFunc);
         this._alternativestree = param1.addChild(this._alternativestreeFunc);
      }
      
      private function _nbWavesFunc(param1:ICustomDataInput) : void
      {
         this.nbWaves = param1.readByte();
         if(this.nbWaves < 0)
         {
            throw new Error("Forbidden value (" + this.nbWaves + ") on element of GameRolePlayGroupMonsterWaveInformations.nbWaves.");
         }
      }
      
      private function _alternativestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._alternativestree.addChild(this._alternativesFunc);
            _loc3_++;
         }
      }
      
      private function _alternativesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:GroupMonsterStaticInformations = ProtocolTypeManager.getInstance(GroupMonsterStaticInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.alternatives.push(_loc3_);
      }
   }
}
